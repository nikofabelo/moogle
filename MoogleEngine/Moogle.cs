namespace MoogleEngine;

public class Moogle
{
	private bool isRunning = false;
	private Corpus? corpus = null;
	private Matrix? matrix = null;

	public SearchResult Query(string queryStr)
	{
		if(!this.isRunning)
		{
			this.isRunning = true;
			int initTime = Environment.TickCount;

			Inform("Loading Corpus...");
			this.corpus = new Corpus("../Content");

			Inform("Generating Matrix...");
			this.matrix = this.corpus.Matrix;

			TimeSpan time = TimeSpan.FromMilliseconds(
				Environment.TickCount-initTime);
			Inform("All Done! 👍 "+string.Format(
				"{0:D2} minutes, {1:D2} seconds",
				time.Minutes, time.Seconds));
		}

		int callTime = Environment.TickCount;

		Inform("Vectorizing Query: \""+queryStr+"\"");
		Vector query = new Query(queryStr, this.corpus!).Vector;

		Inform("Computing Cosine Similarity...");
		Dictionary<Document, double> ranking = new Dictionary<Document, double>();
		Document[] documents = this.corpus!.Documents;
		for(int i = 0; i < documents.Length; i++)
		{
			double cosine = ComputeCosineSimilarity(query, this.matrix![i]);
			if(cosine > 0) ranking.Add(documents[i], cosine);
		}
		ranking = ranking.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

		List<SearchItem> searchItems = new List<SearchItem>();
		foreach(var kvp in ranking)
		{
			Document document = kvp.Key;
			searchItems.Add(new SearchItem(
				document.Name, document.Snippet,
				document.FilePath, kvp.Value));
		}

		TimeSpan queryTime = TimeSpan.FromMilliseconds(
			Environment.TickCount-callTime);
		Inform("Query Done! 👍 "+string.Format(
			"{0:D2} minutes, {1:D2} seconds",
			queryTime.Minutes, queryTime.Seconds));
		return new SearchResult(searchItems.ToArray(), queryStr);
	}

	public double ComputeCosineSimilarity(Vector query, Vector document)
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