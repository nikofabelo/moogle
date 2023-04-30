namespace MoogleEngine;

public static class MoogleEngine
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
		double[] cosines = new double[corpus.Length];
		for(int i = 0; i < cosines.Length; i++)
		{
			cosines[i] = MoogleMath.ComputeCosineSimilarity(query, matrix[i]);
			Console.WriteLine("{0}\n\t{1}", corpus.Documents[i].Name, cosines[i]);
		}
		Debug.TravelArray(cosines);

// 		//cosines = Quicksort(cosines);

// 		List<SearchItem> items = new List<SearchItem>();
// 		for(int i = 0; i < cosines.Length; i++)
// 		{
// 			double cosine = cosines[i];
// 			Document document = corpus.Documents[i];
// 			// if(cosine > 0)
// 			// {
// 				items.Add(new SearchItem(
// 					document.Name, document.Snippet,
// 					document.FilePath, cosine));
// 			// }
// 		}

		TimeSpan time = TimeSpan.FromMilliseconds(
			Environment.TickCount-callTime);
		Inform("All Done! 👍 "+string.Format(
			"{0:D2} minutes, {1:D2} seconds",
			time.Minutes, time.Seconds));

// 		return new SearchResult(items.ToArray(), queryStr);

		return new SearchResult(); // XXX
	}

	public static void Inform(string msg)
	{
		Console.WriteLine("\x1b[33;40mMoogleEngine\x1b[0m: {0}", msg);
	}
}