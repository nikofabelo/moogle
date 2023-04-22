using System.Text;
using System.Text.RegularExpressions;

namespace MoogleEngine;

public class Document
{
	public string[] words = new string[]{};
	private Dictionary<string, double> tf = new Dictionary<string, double>();

	public Document(string path)
	{
		ReadDocument(path);
		CalculateTF();
	}

	public double GetTF(string word)
	{
		try { return tf[word]; }
		catch { return 0; }
	}

	public int GetWordCount()
	{
		return tf.Count;
	}

	public Vector GetVector(Dictionary<string, double> idf)
	{
		return new Vector(tf, idf);
	}

	public void CalculateTF()
	{
		foreach(string word in this.words)
		{
			if(!tf.ContainsKey(word))
				this.tf[word] = 1;
			else
				this.tf[word]++;
		}
		foreach(string word in this.words)
			this.tf[word] /= this.words.Length;
	}

	public void ReadDocument(string path)
	{
		try
		{
			Regex r = new Regex("[^a-z0-9]", RegexOptions.Compiled);
			if(!path.StartsWith("query_"))
			{
				this.words = File.ReadAllLines(path, Encoding.UTF8)
					.SelectMany(line => r.Split(line.ToLower()))
					.Where(w => !string.IsNullOrWhiteSpace(w))
					.ToArray();
			}
			else
			{
				this.words = r.Split(path.Substring("query_".Length).ToLower())
					.Where(w => !string.IsNullOrWhiteSpace(w)).ToArray();
			}
		}
		catch
		{
			throw new IOException("Document not processed: "+path);
		}
	}
}