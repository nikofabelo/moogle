namespace MoogleEngine;

public class SearchItem
{
	public SearchItem(string title, string snippet, string filePath, double score)
	{
		this.Title = title;
		this.Snippet = snippet;
		this.FilePath = filePath;
		this.Score = score;
	}

	public string Title { get; private set; }

	public string Snippet { get; private set; }

	public string FilePath { get; private set; }

	public double Score { get; private set; }
}