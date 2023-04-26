namespace MoogleEngine;

public static class Moogle
{
	public static SearchResult Query(string queryStr)
	{
		// TODO
		// V	Computar similitud cosenica entre el vector del query y cada documento.
		// VI	Ordenar de mayor a menor los vectores documento segun la similitud cosenica.

		int startTime = Environment.TickCount;

		Inform("Loading Corpus...");
		Corpus corpus = new Corpus("../Content");
		Inform("Generating Matrix...");
		Matrix matrix = corpus.Matrix;
		Inform("Vectorizing Query: \""+queryStr+"\"");
		Vector query = new Query(queryStr, corpus.IDF).Vector;

		Inform("Computing Cosine Similarity...");

		// double[] cosines = new double[corpus.Length];
		// for(int i = 0; i < matrix.Length; i++)
		// {
		// 	cosines[i] = ComputeCosine(query, matrix[i]);
		// }
		//cosines = Quicksort(cosines);
		// cosO = (dotProduct(d2, q))/(normVector(d2) * normVector(q))
		// dot product = sum(xi * yi) for i = 1 to n,
		// where xi and yi are the ith elements of the two vectors,
		// and n is the number of elements in the vectors.

		TimeSpan t = TimeSpan.FromMilliseconds(Environment.TickCount-startTime);
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

	// cosine_similarity = dot_product(queryVector, documentVector) /
	//						(magnitude(queryVector) * magnitude(documentVector))
	// optimize the dot product calculation by only considering the non-zero elements of each vector
	public static double CalculateCosineSimilarity(Vector query, Vector document)
	{
		double dotProduct = 0;

		if(query.Length < document.Length)
		{
			Vector temp = query;
			query = document;
			document = temp;
		}

		for(int i = 0; i < query.Length; i++)
			dotProduct += query[i]*document[i];

		return dotProduct / query.Norm * document.Norm;
	}
		// 		double cosineSimilarity = dotProduct / (Math.Sqrt(normA) * Math.Sqrt(normB));

		// 		return cosineSimilarity;
		// 	}
		// }

		// 	static void Main(string[] args)
		// 	{
		// 		double[] queryVector = new double[] { 1.2, 3.4, 5.6 };
		// 		List<double[]> documentVectors = new List<double[]>
		// 		{
		// 			new double[] { 0.1, 0.2, 0.3 },
		// 			new double[] { 0.4, 0.5, 0.6 },
		// 			new double[] { 0.7, 0.8, 0.9 }
		// 		};

		// 		// calculate the magnitude of the query vector
		// 		double queryMagnitude = Math.Sqrt(queryVector.Select(x => x * x).Sum());

		// 		// calculate cosine similarity for each document vector
		// 		foreach (double[] documentVector in documentVectors)
		// 		{
		// 			double dotProduct = queryVector.Zip(documentVector, (a, b) => a * b).Sum();
		// 			double documentMagnitude = Math.Sqrt(documentVector.Select(x => x * x).Sum());
		// 			double cosineSimilarity = dotProduct / (queryMagnitude * documentMagnitude);
		// 			// do something with cosineSimilarity, such as store it in a list or dictionary
		// 			Console.WriteLine(cosineSimilarity);
		// 		}
		// 	}

	public static void Inform(string msg)
	{
		Console.WriteLine("\x1b[33;40mMoogleEngine\x1b[0m: {0}", msg);
	}
}