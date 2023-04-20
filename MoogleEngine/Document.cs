using System.Text;
using System.Text.RegularExpressions;

namespace MoogleEngine;

public class Document
{
	private string[] words;
	private Dictionary<string, float> tf;

	public Document(string path)
	{
		// Split Document in words
		try
		{
			Regex r = new Regex("[^a-z0-9]", RegexOptions.Compiled);
			words = File.ReadAllLines(path, Encoding.UTF8)
				.SelectMany(line => r.Split(line.ToLower()))
				// .Select(w => w.Trim())
				.Where(w => !string.IsNullOrWhiteSpace(w))
				.ToArray();
		}
		catch
		{
			words = new string[]{};
			Console.WriteLine("Unprocessed Document:\t"+path);
		}

		// Calculate TF
		tf = new Dictionary<string, float>();
		foreach(string word in words)
		{
			if(!tf.ContainsKey(word))
				tf[word] = 1;
			else
				tf[word]++;
		}
		foreach(string word in words)
			tf[word] /= words.Length;

		Debug.TravelDict(tf);
	}
}