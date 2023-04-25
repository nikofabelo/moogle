namespace MoogleEngine;

public class Query
{
	private Vector queryVector;

	public Query(string query, Dictionary<string, double> corpusIDF)
	{
		Document document = new Document("q_"+query);
		foreach(string word in document.Words)
			if(!corpusIDF.ContainsKey(word))
				corpusIDF[word] = 0;
		this.queryVector = document.GetVector(corpusIDF);
	}

	public Vector Vector { get { return this.queryVector; } }
}