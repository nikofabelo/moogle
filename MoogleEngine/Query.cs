namespace MoogleEngine;

// Inicializa cada Query como un documento
public class Query
{
	private Document document;
	private Vector queryVector;

	public Query(string query, Corpus corpus)
	{
		/**
			En lugar de una ruta a archivo como parametro para
			la creacion del documento se usa el propio texto
			del Query con el identificador "q_" que sirve
			para diferenciar el Query de los demas documentos
		*/
		this.document = new Document("q_" + query, corpus);
		this.queryVector = this.document.GetVector();
	}

	public Document Document { get { return this.document; } }

	public Vector Vector { get { return this.queryVector; } }
}