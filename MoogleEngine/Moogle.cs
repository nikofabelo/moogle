namespace MoogleEngine;

public static class Moogle
{
	public static SearchResult Query(string queryStr)
	{
		int callTime = Environment.TickCount;

		Inform("Loading Corpus...");
		Corpus corpus = new Corpus("../Content");

		Inform("Generating Matrix...");
		Matrix matrix = corpus.Matrix;

		Inform("Vectorizing Query: \""+queryStr+"\"");
		Vector query = new Query(queryStr, corpus.IDF).Vector;

		Inform("Computing Cosine Similarity...");
		Dictionary<Document, double> ranking = new Dictionary<Document, double>();
		Document[] documents = corpus.Documents;
		for(int i = 0; i < corpus.Length; i++)
		{
			ranking.Add(documents[i],
				ComputeCosineSimilarity(query, matrix[i])+i); // FIXME -i
			Console.WriteLine("{0}\n\t{1}", corpus.Documents[i].Name,
				ComputeCosineSimilarity(query, matrix[i]));
		}
		ranking = ranking.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
		// Debug.TravelDict(ranking);

		List<SearchItem> searchItems = new List<SearchItem>();
		foreach(var kvp in ranking)
		{
			Document document = kvp.Key;
			searchItems.Add(new SearchItem(
				document.Name, document.Snippet,
				document.FilePath, kvp.Value));
		}

		TimeSpan time = TimeSpan.FromMilliseconds(
			Environment.TickCount-callTime);
		Inform("All Done! 👍 "+string.Format(
			"{0:D2} minutes, {1:D2} seconds",
			time.Minutes, time.Seconds));

		return new SearchResult(searchItems.ToArray(), queryStr);
	}

	public static double ComputeCosineSimilarity(Vector query, Vector document)
	{
		if(query.Length > document.Length)
		{
			Vector temp = document;
			document = query;
			query = temp;
		}

		double dotProduct = 0;
		for(int i = 0; i < query.Length; i++)
		{
			dotProduct += query[i]*document[i];
		}
// 		Console.WriteLine(query.Norm*document.Norm);

		return (dotProduct)/(1e-10+query.Norm*document.Norm);
	}

	public static void Inform(string msg)
	{
		Console.WriteLine("\x1b[33;40mMoogleEngine\x1b[0m: {0}", msg);
	}
}