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

	public Dictionary<string, double> IDF { get { return this.idf; } }

	public Document[] Documents { get { return this.documents; } }

	public int Length { get { return Documents.Length; } }

	public Matrix Matrix { get { return new Matrix(documents, IDF); } }

	private void CalculateIDF()
	{
		foreach(Document d in Documents)
		{
			foreach(string word in d.Words)
			{
				if(!IDF.ContainsKey(word))
				{
					double dtf = 0;
					foreach(Document document in Documents)
						if(document.GetTF(word) > 0) dtf += 1;
					IDF[word] = Math.Log(Length / dtf);
				}
			}
		}
	}

	private void ReadDocuments(string path)
	{
		string[] directoryFiles = Directory.GetFiles(
			path.Replace('/', Path.DirectorySeparatorChar), "*.txt");
		this.documents = new Document[directoryFiles.Length];
		for(int i = 0; i < Length; i++)
		{
			// Moogle.Inform("Reading documents ("+(i+1)+"/"+directoryFiles.Length+")\n\t"+directoryFiles[i]); FIXME
			this.documents[i] = new Document(directoryFiles[i]);
		}
	}
}