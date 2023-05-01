namespace MoogleEngine;

public class Query
{
	private Vector queryVector;

	public Query(string query, Dictionary<string, double> idf)
	{
		Document document = new Document("q_"+query);
		this.queryVector = document.GetVector(idf);
	}

	public Vector Vector { get { return this.queryVector; } }
}