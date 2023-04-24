namespace MoogleEngine;

public static class Moogle
{
	public static SearchResult Query(string queryStr)
	{
		// TODO
		// V	Computar similitud cosenica entre el vector del query y cada documento.
		// VI	Ordenar de mayor a menor los vectores documento segun la similitud cosenica.
		Inform("Loading Corpus...");
		Corpus corpus = new Corpus("../Content");
		Inform("Generating Matrix...");
		Matrix matrix = corpus.GetMatrix();
		Inform("Vectorizing Query: \""+queryStr+"\"");
		Query query = new Query(queryStr, corpus.GetIDF(), corpus.Length);

		Inform("Computing Cosine Similarity...");

		foreach(double[] d in matrix.AsDoubles())
		{
			// Debug.TravelArray(d);
			// Debug.TravelArray(query.GetVector().AsDouble());
			// double cos = ()/(d);
			// Console.WriteLine(cos);
		}

		// cosO = (dotProduct(d2, q))/(normVector(d2) * normVector(q))
		// dot product = sum(xi * yi) for i = 1 to n,
		// where xi and yi are the ith elements of the two vectors,
		// and n is the number of elements in the vectors.

		Inform("All Done! 👍");

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