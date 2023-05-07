namespace MoogleEngine;

// Inicializa el Query como un documento
public class Query
{
	private Document document;
	private Vector queryVector;

	public Query(string query, Corpus corpus)
	{
		this.document = new Document("q_"+query, corpus);
		this.queryVector = this.document.GetVector();
	}

	public Document Document { get { return this.document; } }

	public Vector Vector { get { return this.queryVector; } }
}