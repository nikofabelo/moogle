using System.Text;
using System.Text.RegularExpressions;

namespace MoogleEngine;

public class Document
{
	public string[] words = new string[]{};
	private Dictionary<string, double> tf = new Dictionary<string, double>();
	string path; // XXX
	public Document(string path)
	{
		this.path = path; // XXX
		ReadDocument(path);
		CalculateTF();
	}

	public string GetPath() {return this.path;} // XXX

	public double GetTF(string word)
	{
		try { return tf[word]; }
		catch { return 0; }
	}

	public Vector GetVector(Dictionary<string, double> idf, int l)
	{
		return new Vector(tf, idf, l);
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
			// if(!path.StartsWith('q'))
			// {
				this.words = File.ReadAllLines(path, Encoding.UTF8)
					.SelectMany(line => r.Split(line.ToLower()))
					.Where(w => !string.IsNullOrWhiteSpace(w))
					.ToArray();
			// }
			// else
			// {
			// 	this.words = path.ToLower().Split().Select(w => w.Trim()).ToArray();
			// 	Debug.TravelArray(this.words);
			// }
		}
		catch
		{
			throw new IOException("Document not processed: "+path);
		}
	}
}