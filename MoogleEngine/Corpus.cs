namespace MoogleEngine;

public class Corpus
{
	private Dictionary<string, double> idf = new Dictionary<string, double>();
	private Dictionary<string, int> dtf = new Dictionary<string, int>();
	private Document[] documents = new Document[]{};

	public Corpus(string path)
	{
		ReadDocuments(path);
		CalculateIDF();
	}

	public Dictionary<string, double> IDF { get { return this.idf; } }

	public Dictionary<string, int> DTF
	{
		get
		{
			return this.dtf;
		}
		set
		{
			this.dtf = value;
		}
	}

	public Document[] Documents { get { return this.documents; } }

	public Matrix Matrix { get { return new Matrix(this.documents); } }

	/**
		Calcula el valor de IDF para cada palabra del
		diccionario dtf que funciona como banco de palabras
	*/
	private void CalculateIDF()
	{
		foreach(string word in this.dtf.Keys)
		{
			// IDF = log(cantidad_documentos / documentos_aparece_palabra)
			this.idf[word] = Math.Log(this.documents.Length / this.dtf[word]);
		}
	}

	private void ReadDocuments(string path)
	{
		/**
			Obtiene los nombres de archivos con extension .txt
			del directorio que contiene el Corpus
			Crea un arreglo de documentos y agnade cada documento
		*/
		string[] directoryFiles = Directory.GetFiles(
			path.Replace('/', Path.DirectorySeparatorChar), "*.txt");
		this.documents = new Document[directoryFiles.Length];
		for(int i = 0; i < this.documents.Length; i++)
		{
			Moogle.Inform("Reading Document ("+(i+1)+"/"+directoryFiles.Length+")\n\t"+directoryFiles[i]);
			this.documents[i] = new Document(directoryFiles[i], this);
		}
	}
}