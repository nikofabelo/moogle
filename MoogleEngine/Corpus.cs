namespace MoogleEngine;

// Carga el Corpus de documentos y calcula el IDF
public class Corpus
{
	private Dictionary<string, double> dtf = new Dictionary<string, double>();
	private Dictionary<string, double> idf = new Dictionary<string, double>();
	private Document[] documents = new Document[0];

	public Corpus(string path)
	{
		ReadDocuments(path);
		CalculateIDF();
	}

	/**
		Calcula el valor de IDF para cada palabra del
		diccionario dtf que funciona como banco de palabras
	*/
	private void CalculateIDF()
	{
		foreach(string word in this.dtf.Keys)
		{
			// IDF = log(cantidad_documentos / documentos_aparece_palabra)
			this.idf[word] = System.Math.Log(this.documents.Length / this.dtf[word]);
		}
	}

	/**
		Obtiene los nombres de archivos con extension .txt
		en el directorio que contiene el Corpus, posteriormente
		crea un arreglo de documentos y agnade cada documento
	*/
	private void ReadDocuments(string path)
	{
		string[] directoryFiles = Directory.GetFiles(
			path.Replace('/', Path.DirectorySeparatorChar), "*.txt");
		this.documents = new Document[directoryFiles.Length];
		for(int i = 0; i < this.documents.Length; i++)
		{
			Moogle.Inform("Reading Document ("+(i+1)+"/"+directoryFiles.Length+")\n\t"+directoryFiles[i]);
			this.documents[i] = new Document(directoryFiles[i], this);
		}
	}

	public Dictionary<string, double> DTF
	{
		get { return this.dtf; }
		set { this.dtf = value; }
	}

	public Dictionary<string, double> IDF { get { return this.idf; } }

	public Document[] Documents { get { return this.documents; } }

	public Matrix Matrix { get { return new Matrix(this.documents); } }
}