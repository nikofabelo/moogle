using System.Text;
using System.Text.RegularExpressions;

namespace MoogleEngine;

// Define un mejor acceso a las propiedades de documentos
public class Document
{
	private Corpus corpus;
	private Dictionary<string, double> tf = new Dictionary<string, double>();
	private string name = "";
	private string snippet = "";
	private string filePath = "";
	private string[] words = new string[] { };

	// Constante de expresion regular que elimina todos los caracteres excepto los alfanumericos
	static readonly Regex r = new Regex("[^a-z0-9]", RegexOptions.Compiled);

	public Document(string path, Corpus corpus)
	{
		this.corpus = corpus;

		ReadDocument(path);
		CalculateTF();
	}

	/**
		Para cada palabra del documento se va agnadiendo
		su frequencia en el documento al diccionario tf
		Al descubrise una palabra por primera vez en el
		documento se aumenta su frequencia de aparicion
		en documentos mediante el diccionario dtf
	*/
	private void CalculateTF()
	{
		foreach (string word in this.words)
		{
			if (!this.tf.ContainsKey(word))
			{
				this.tf[word] = 1;
				if (!this.corpus.DTF.ContainsKey(word))
				{
					this.corpus.DTF[word] = 1;
				}
				else
				{
					this.corpus.DTF[word]++;
				}
			}
			else
			{
				this.tf[word]++;
			}
		}
		// TF = repeticiones_palabra / cantidad_palabras_documento
		foreach (string word in this.tf.Keys)
		{
			this.tf[word] /= this.words.Length;
		}
	}

	/**
		Lee el documento y lo divide en palabras, manteniendo solamente
		los caracteres alfanumericos y llevando el texto a minusculas
		Igualmente guarda el nombre del documento, su snippet y su
		ubicacion o ruta de acceso
		En caso de que el documento a crear corresponda al Query solo
		se dividen las palabras de este, para identificar el Query
		se usa un prefijo delante de la ruta del archivo: "q_"
	*/
	private void ReadDocument(string path)
	{
		if (!path.StartsWith("q_"))
		{
			try
			{
				/**
					Lee las lineas del archivo una por una utilizando UTF-8
					como codificacion, lleva cada linea a minusculas y luego
					las divide en palabras, eliminando los simbolos o caracteres
					no alfanumericos y las palabras vacias
				*/
				this.words = File.ReadAllLines(path, Encoding.UTF8)
					.SelectMany(line => r.Split(line.ToLower()))
					.Where(w => !string.IsNullOrWhiteSpace(w))
					.ToArray();

				// Obtiene un snippet de un minimo de 100 palabras para el documento
				List<string> lines = new List<string>();
				using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
				{
					/**
						La primera condicion se cumple siempre que no se haya alcanzado el
						limite de 100 palabras del snippet y la segunda condicion siempre
						que exista una nueva linea por leer
					*/
					while (lines.Sum(line => line.Split(' ').Length) < 100 && sr.Peek() > -1)
					{
						lines.Add(sr.ReadLine()!);
					}
				}
				this.snippet = string.Join(" ", lines).TrimEnd() + "...";
			}
			// Lanza una excepcion en caso de un error de lectura del documento
			catch
			{
				throw new IOException("Document not processed: " + path);
			}
			this.name = Path.GetFileNameWithoutExtension(path);
			/**
				Prepara la ruta de acceso al archivo mediante el uso
				de /Content/NombreArchivo, configurado en MoogleServer
			*/
			this.filePath = "/Content/" + this.name + ".txt";
		}
		else
		{
			// Divide en palabras el texto del Query eliminandole el prefijo "q_"
			this.words = r.Split(path.Substring("q_".Length).ToLower())
				.Where(w => !string.IsNullOrWhiteSpace(w)).ToArray();
		}
	}

	public string Name { get { return this.name; } }

	public string Snippet { get { return this.snippet; } }

	public string FilePath { get { return this.filePath; } }

	public string[] Words { get { return this.words; } }

	public Vector GetVector()
	{
		return new Vector(this.tf, this.corpus.IDF);
	}
}