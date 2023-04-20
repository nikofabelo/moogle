namespace MoogleEngine;

public class Dataset
{
	private string[] directoryFiles;
	private Document[] documents;

	public Dataset(string path)
	{
		// Carga los documentos en Content
		directoryFiles = Directory.GetFiles(
			"../Content".Replace('/', Path.DirectorySeparatorChar), "*.txt");
		documents = new Document[directoryFiles.Length];
		for(int i = 0; i < directoryFiles.Length; i++)
			documents[i] = new Document(directoryFiles[i]);

		// TODO POE, DOCS, STEPS;
		// TODO DATASET TO MATRIX && MAKE DEV
	}

	static void TravelArray(string[] a)
	{
		foreach(string b in a)
		{
			Console.WriteLine(b);
		}
	}
}