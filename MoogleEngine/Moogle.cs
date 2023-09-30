namespace MoogleEngine;

public class Moogle
{
	// Define un flag que permite saber si ya se ha iniciado el motor de busqueda
	private bool isRunning = false;
	private Corpus? corpus = null;
	private Matrix? matrix = null;

	public SearchResult Query(string queryStr)
	{
		/**
			En caso de que no se haya iniciado el motor se creara
			el Corpus leyendo todos los documentos en ../Content
			Seguidamente se genera la matriz de documentos
			Esto solo ocurre una vez ya que isRunning se vuelve true
		*/
		if (!this.isRunning)
		{
			this.isRunning = true;
			int initTime = Environment.TickCount;

			Inform("Loading Corpus...");
			this.corpus = new Corpus("../Content");

			Inform("Generating Matrix...");
			this.matrix = this.corpus.Matrix;

			TimeSpan time = TimeSpan.FromMilliseconds(
				Environment.TickCount - initTime);
			Inform("All Done! 👍 " + string.Format(
				"{0:D2} minutes, {1:D2} seconds",
				time.Minutes, time.Seconds));
		}

		int callTime = Environment.TickCount;

		// En todo caso se crea un Vector del texto del Query
		Inform("Vectorizing Query: \"" + queryStr + "\"");
		Query query = new Query(queryStr, this.corpus!);
		Vector queryVector = query.Vector;

		/**
			Se calcula la similitud cosenica entre el Vector
			del Query y cada documento, creando asi un valor
			de ranking para cada documento que luego se ordena
		*/
		Inform("Computing Cosine Similarity...");
		Dictionary<Document, double> ranking = new Dictionary<Document, double>();
		Document[] documents = this.corpus!.Documents;
		for (int i = 0; i < documents.Length; i++)
		{
			double cosine = ComputeCosineSimilarity(queryVector, this.matrix![i]);
			// Si los vectores no son ortogonales los agnade a la lista de resultados
			if (cosine > 0) ranking.Add(documents[i], cosine);
		}
		// Ordena de manera descendiente los documentos por su valor de ranking
		ranking = ranking.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

		// Incluye en el SearchResult los SearchItem de la busqueda
		List<SearchItem> searchItems = new List<SearchItem>();
		foreach (var kvp in ranking)
		{
			Document document = kvp.Key;
			searchItems.Add(new SearchItem(
				document.Name, document.Snippet,
				document.FilePath, kvp.Value));
		}

		/**
			Calcula una sugerencia para cuando la búsqueda devuelva
			pocos resultados, utilizando para esto el metodo de Levenshtein
		*/
		string suggestion = "";
		if (ranking.Count < 5)
		{
			Inform("Generating Suggestion...");
			List<string> suggestionWords = new List<string>();
			foreach (string word in query.Document.Words)
			{
				string replacement = word;
				int c = int.MaxValue;
				foreach (string key in corpus.DTF.Keys)
				{
					int d = LevenshteinDistance(word, key);
					if (d < c && d > 1)
					{
						replacement = key;
						c = d;
					}
				}
				suggestionWords.Add(replacement);
			}
			suggestion = (suggestionWords.Count < 0) ? queryStr : string.Join(" ", suggestionWords);
		}

		TimeSpan queryTime = TimeSpan.FromMilliseconds(
			Environment.TickCount - callTime);
		Inform("Query Done! 👍 " + string.Format(
			"{0:D2} minutes, {1:D2} seconds",
			queryTime.Minutes, queryTime.Seconds));
		return new SearchResult(searchItems.ToArray(), suggestion);
	}

	/**
		Calcula la similitud cosenica entre dos vectores donde
		cos = (vector1 * vector2)/(magnitud_vector1 * magnitud_vector2)
	*/
	public double ComputeCosineSimilarity(Vector query, Vector document)
	{
		double dotProduct = 0;
		for (int i = 0; i < query.Length; i++)
			dotProduct += query[i] * document[i];
		return dotProduct / (query.Norm * document.Norm);
	}

	public static void Inform(string msg)
	{
		Console.WriteLine("\x1b[33;40mMoogleEngine\x1b[0m: {0}", msg);
	}

	public int LevenshteinDistance(string a, string b)
	{
		int m = a.Length;
		int n = b.Length;
		int[,] d = new int[m + 1, n + 1];
		for (int i = 0; i <= m; i++)
		{
			d[i, 0] = i;
		}
		for (int j = 0; j <= n; j++)
		{
			d[0, j] = j;
		}
		for (int j = 1; j <= n; j++)
		{
			for (int i = 1; i <= m; i++)
			{
				if (a[i - 1] == b[j - 1])
				{
					d[i, j] = d[i - 1, j - 1];
				}
				else
				{
					int deletion = d[i - 1, j] + 1;
					int insertion = d[i, j - 1] + 1;
					int substitution = d[i - 1, j - 1] + 1;
					d[i, j] = System.Math.Min(System.Math.Min(deletion, insertion), substitution);
				}
			}
		}
		return d[m, n];
	}
}