using System.Text;
using System.Text.RegularExpressions;

namespace MoogleEngine;

public class Document
{
	private Dictionary<string, double> tf = new Dictionary<string, double>();
	private string[] words = new string[]{};

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

	public int GetTermCount()
	{
		return tf.Count;
	}

	public string[] Words { get { return this.words; } }

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
		Regex r = new Regex("[^a-z0-9]", RegexOptions.Compiled);
		if(!path.StartsWith("q_"))
		{
			try
			{
				this.words = File.ReadAllLines(path, Encoding.UTF8)
					.SelectMany(line => r.Split(line.ToLower()))
					.Where(w => !string.IsNullOrWhiteSpace(w))
					.ToArray();
			}
			catch
			{
				throw new IOException("Document not processed: "+path);
			}
		}
		else
		{
			this.words = r.Split(path.Substring("q_".Length).ToLower())
				.Where(w => !string.IsNullOrWhiteSpace(w)).ToArray();
		}
	}
}