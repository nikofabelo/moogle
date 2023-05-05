namespace MoogleEngine;

public class Query
{
	private Vector queryVector;

	public Query(string query, Corpus corpus)
	{
		Document document = new Document("q_"+query, corpus);
		this.queryVector = document.GetVector();
	}

	public Vector Vector { get { return this.queryVector; } }
}