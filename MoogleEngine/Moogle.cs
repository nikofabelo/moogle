namespace MoogleEngine;

public static class Moogle
{
	public static SearchResult Query(string query)
	{
		// IV	Repetir con el query.
		// V	Computar similitud cosenica entre el vector del query y cada documento.
		// VI	Ordenar de mayor a menor los vectores documento segun la similitud cosenica.

		Console.WriteLine("Loading Corpus...");
		Corpus corpus = new Corpus("../Content");
		Console.WriteLine("Generating Matrix...");
		Matrix matrix = corpus.GetMatrix();

		//Document queryDoc = new Document("q"+query);

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

		return new SearchResult(items, query);
	}
}