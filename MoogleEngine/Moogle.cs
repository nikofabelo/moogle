namespace MoogleEngine;

public static class Moogle
{
	public static SearchResult Query(string queryStr)
	{
		// TODO
		// V	Computar similitud cosenica entre el vector del query y cada documento.
		// VI	Ordenar de mayor a menor los vectores documento segun la similitud cosenica.
		int t0 = Environment.TickCount;

		Inform("Loading Corpus...");
		Corpus corpus = new Corpus("../Content");
		Inform("Generating Matrix...");
		Matrix matrix = corpus.Matrix;
		Inform("Vectorizing Query: \""+queryStr+"\"");
		Vector query = new Query(queryStr, corpus.IDF).Vector;

		Inform("Computing Cosine Similarity...");

		double[] cosines = new double[corpus.Length];
		for(int i = 0; i < matrix.Length; i++)
		{
			//cosines[i] = ComputeCosine(query, matrix[i]);
		}
		//cosines = Quicksort(cosines);
		// cosO = (dotProduct(d2, q))/(normVector(d2) * normVector(q))
		// dot product = sum(xi * yi) for i = 1 to n,
		// where xi and yi are the ith elements of the two vectors,
		// and n is the number of elements in the vectors.

		TimeSpan t = TimeSpan.FromMilliseconds(Environment.TickCount-t0);
		string time = string.Format("{0:D2} minutes, {1:D2} seconds", t.Minutes, t.Seconds);
		Inform("All Done! 👍 "+time);

		SearchItem[] items = new SearchItem[12] {
			new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.9f),
			new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.5f),
			new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.1f),
			new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.9f),
			new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.5f),
			new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.9f),
			new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.5f),
			new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.1f),
			new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.9f),
			new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.5f),
			new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.9f),
			new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.5f)
		};

		return new SearchResult(items, queryStr);
	}

	public static void Inform(string msg)
	{
		Console.WriteLine("\x1b[33;40mMoogleEngine\x1b[0m: {0}", msg);
	}
}