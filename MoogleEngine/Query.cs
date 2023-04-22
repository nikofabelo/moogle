namespace MoogleEngine;

public class Query
{
	public Query(string query, Dictionary<string, double> idf, int corpusLength)
	{
		Document document = new Document("query_"+query);
		foreach(string word in document.words)
			if(!idf.ContainsKey(word))
				idf[word] = Math.Log(corpusLength);
		Vector vector = document.GetVector(idf);
	}
}