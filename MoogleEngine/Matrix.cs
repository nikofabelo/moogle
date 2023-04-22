namespace MoogleEngine;

public class Matrix
{
	private double[,] matrix;

	public Matrix(Document[] documents, Dictionary<string, double> idf)
	{
		int x = 0;
		foreach(Document document in documents)
		{
			int c = document.GetWordCount();
			if(c > x) x = c;
		}
		int y = documents.Length;
		this.matrix = new double[x,y];

		for(int i = 0; i < y; i++)
		{
			Vector v = documents[i].GetVector(idf, x);
			for(int j = 0; j < x; j++)
			{
				Console.WriteLine("i: {0}\tj: {1}\tv[j]: {2}", i, j, v[j]); // XXX
				this.matrix[j,i] = v[j];
			}
		}

		Debug.TravelMatrix(this.matrix);
	}
}