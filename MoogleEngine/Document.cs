using System.Text;
using System.Text.RegularExpressions;

namespace MoogleEngine;

public class Document
{
	private Dictionary<string, double> tf = new Dictionary<string, double>();
	private string name = "";
	private string snippet = "";
	private string filePath = "";
	private string[] words = new string[]{};

	static readonly Regex r = new Regex("[^a-z0-9]", RegexOptions.Compiled);

	public Document(string path)
	{
		ReadDocument(path);
		CalculateTF();
	}

	public bool Contains(string word)
	{
		return this.tf.TryGetValue(word, out _);
	}

	public string Name { get { return this.name; } }

	public string Snippet { get { return this.snippet; } }

	public string FilePath { get { return this.filePath; } }

	public string[] Words { get { return this.words; } }

	public Vector GetVector(Dictionary<string, double> idf)
	{
		return new Vector(this.tf, idf);
	}

	private void CalculateTF()
	{
		foreach(string word in this.words)
		{
			if(!this.tf.ContainsKey(word))
			{
				this.tf[word] = 1;
			}
			else
			{
				this.tf[word]++;
			}
		}
		foreach(string word in this.words)
		{
			this.tf[word] /= this.words.Length;
		}
	}

	private void ReadDocument(string path)
	{
		if(!path.StartsWith("q_"))
		{
			try
			{
				this.words = File.ReadAllLines(path, Encoding.UTF8)
					.SelectMany(line => r.Split(line.ToLower()))
					.Where(w => !string.IsNullOrWhiteSpace(w))
					.ToArray();

				List<string> lines = new List<string>();
				using(StreamReader sr = new StreamReader(path, Encoding.UTF8))
				{
					while(lines.Count < 18 && sr.Peek() > -1) // FIXME 18 ?
					{
						lines.Add(sr.ReadLine()!);
					}
				}
				this.snippet = string.Join(" ", lines);
			}
			catch
			{
				throw new IOException("Document not processed: "+path);
			}
			this.name = Path.GetFileNameWithoutExtension(path);
			this.filePath = "/Content/"+this.name+".txt"; // FIXME Content/ == /Content/
		}
		else
		{
			this.words = r.Split(path.Substring("q_".Length).ToLower())
				.Where(w => !string.IsNullOrWhiteSpace(w)).ToArray();
		}
	}
}