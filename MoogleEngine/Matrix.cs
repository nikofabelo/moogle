namespace MoogleEngine;

public class Matrix
{
	private double[,] matrix;

	public Matrix(Document[] documents, Dictionary<string, double> idf)
	{
		int x = 0;
		foreach(Document document in documents)
		{
			Vector v = document.GetVector(idf);
			if(v.Length > x)
				x = v.Length;
		}
		int y = documents.Length;
		this.matrix = new double[x,y];
		
	}
}