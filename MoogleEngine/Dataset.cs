namespace MoogleEngine;

public class Dataset
{
	private string[] directoryFiles;
	private static Document[] documents;

	public Dataset(string path)
	{
		// Carga los documentos en Content
		directoryFiles = Directory.GetFiles(
			"../Content".Replace('/', Path.DirectorySeparatorChar), "*.txt");
		documents = new Document[directoryFiles.Length];
		for(int i = 0; i < directoryFiles.Length; i++)
			documents[i] = new Document(directoryFiles[i]);

		// Matrix
		documents[0].GetVector();
	}

	// Calculate IDF
	public static double GetIDF(string word)
	{
		double dtf = 0;
		foreach(Document document in documents)
			if(document.GetTF(word) > 0) dtf += 1;
		return Math.Log(documents.Length / dtf);
		// IDF = log(Number of Documents / Number of Documents with Term)
	}
}