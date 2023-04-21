using System.Text;
using System.Text.RegularExpressions;

namespace MoogleEngine;

public class Document
{
	private string[] words;
	private Dictionary<string, double> tf;

	public Document(string path)
	{
		// Split Document in words
		try
		{
			Regex r = new Regex("[^a-z0-9]", RegexOptions.Compiled);
			if(!path.StartsWith('q'))
			{
				words = File.ReadAllLines(path, Encoding.UTF8)
					.SelectMany(line => r.Split(line.ToLower()))
					// .Select(w => w.Trim())
					.Where(w => !string.IsNullOrWhiteSpace(w))
					.ToArray();
			}
			else
			{
				words = path.ToLower().Split().Select(w => w.Trim()).ToArray();
				Debug.TravelArray(words);
			}
		}
		catch
		{
			words = new string[]{};
			Console.WriteLine("Unprocessed Document:\t"+path);
		}

		tf = CalculateTF();
		Debug.TravelDict(tf);
	}

	// Calculate words TF
	public Dictionary<string, double> CalculateTF()
	{
		Dictionary<string, double> d = new Dictionary<string, double>();
		foreach(string word in words)
			if(!d.ContainsKey(word))
				tf[word] = 1;
			else
				tf[word]++;
		foreach(string word in words)
			tf[word] /= words.Length;
		return d;
	}

	// Transforms Document to Vector
	public Vector GetVector()
	{
		return new Vector(tf);
	}

	// Get TF for a word
	public double GetTF(string word)
	{
		try { return tf[word]; }
		catch { return -1; }
	}
}