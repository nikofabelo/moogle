using System.Text;
using System.Text.RegularExpressions;

namespace MoogleEngine;

public class Document
{
	private Dictionary<string, int> tf = new Dictionary<string, int>();
	private static readonly Regex r = new Regex("[^a-z0-9]", RegexOptions.Compiled);
	private string[] words = new string[]{};

	public Document(string path)
	{
		ReadDocument(path);
		CalculateTF();
	}

	public double GetTF(string word)
	{
		return this.tf.TryGetValue(word, out int value) ? value : 0;
	}

	public string[] Words { get { return this.words; } }

	public Vector GetVector(Dictionary<string, double> idf)
	{
		return new Vector(tf, idf);
	}

	private void CalculateTF()
	{
		foreach(string word in Words)
		{
			if(!this.tf.ContainsKey(word))
				this.tf[word] = 1;
			else
				this.tf[word]++;
		}
		foreach(string word in Words)
			this.tf[word] /= Words.Length;
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