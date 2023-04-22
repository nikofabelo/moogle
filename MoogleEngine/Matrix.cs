namespace MoogleEngine;

public class Matrix
{
	private double[,] matrix;

	public Matrix(Document[] documents, Dictionary<string, double> idf)
	{
		int y = 0;
		foreach(Document document in documents)
		{
			Vector v = document.GetVector(idf, y);
			if(v.Length > y)
				y = v.Length;
		}
		int x = documents.Length;
		this.matrix = new double[y,x];

		// for(int i = 0; i < x; i++)
		// {
		// 	for(int j = 0; j < y; j++)
		// 	{
		// 		this.matrix[i,j] = documents[i].GetVector(idf, x)[j];
		// 	}
		// }

		for(int i = 0; i < x; i++)
		{
			Vector v = documents[i].GetVector(idf, y);
			Console.WriteLine(documents[i].GetPath()); // XXX
			for(int j = 0; j < v.Length; j++)
			{
				Console.WriteLine("i: {0}\tj: {1}\tv[j]: {2}", i, j, v[j]);
				this.matrix[j,i] = v[j];
			}
		}

		// Debug.TravelMatrix(this.matrix);
	}
}