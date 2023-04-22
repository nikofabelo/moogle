namespace MoogleEngine;

public class Corpus
{
	private Dictionary<string, double> idf = new Dictionary<string, double>();
	private Document[] documents = new Document[]{};

	public Corpus(string path)
	{
		ReadDocuments(path);
		CalculateIDF();
	}

	public Matrix GetMatrix()
	{
		return new Matrix(documents, idf);
	}

	public void CalculateIDF()
	{
		foreach(Document d in this.documents)
		{
			foreach(string word in d.words)
			{
				if(!idf.ContainsKey(word))
				{
					double dtf = 0;
					foreach(Document document in this.documents)
						if(document.GetTF(word) > 0) dtf += 1;
					if(dtf != 0) dtf = Math.Log(this.documents.Length / dtf);
					idf[word] = dtf;
				}
			}
		}
	}

	public void ReadDocuments(string path)
	{
		string[] directoryFiles = Directory.GetFiles(
			path.Replace('/', Path.DirectorySeparatorChar), "*.txt");
		documents = new Document[directoryFiles.Length];
		for(int i = 0; i < directoryFiles.Length; i++)
		{
			// Console.WriteLine("\x1b[32;40minfo\x1b[0m: Reading documents ({0}/{1})\n\t{2}",
			// 	i+1, directoryFiles.Length, directoryFiles[i]);
			documents[i] = new Document(directoryFiles[i]);
		}
	}
}