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

	public Dictionary<string, double> GetIDF() { return this.idf; }

	public int Length { get { return this.documents.Length; } }

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
			// Moogle.Inform("Reading documents ("+(i+1)+"/"+directoryFiles.Length+")\n\t"+directoryFiles[i]);
			documents[i] = new Document(directoryFiles[i]);
		}
	}
}