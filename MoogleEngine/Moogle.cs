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
		Vector query = new Query(queryStr, corpus).Vector;

		Inform("Computing Cosine Similarity...");
		Dictionary<Document, double> ranking = new Dictionary<Document, double>();
		Document[] documents = corpus.Documents;
		for(int i = 0; i < documents.Length; i++)
		{
			double cosine = ComputeCosineSimilarity(query, matrix[i]);
			if(cosine > 0) ranking.Add(documents[i], cosine);
		}
		ranking = ranking.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
		Debug.TravelDict(ranking);

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
		double dotProduct = 0;
		for(int i = 0; i < query.Length; i++)
			dotProduct += query[i]*document[i];
		return dotProduct/(query.Norm*document.Norm);
	}

	public static void Inform(string msg)
	{
		Console.WriteLine("\x1b[33;40mMoogleEngine\x1b[0m: {0}", msg);
	}
}