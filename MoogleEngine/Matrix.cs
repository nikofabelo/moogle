namespace MoogleEngine;

public class Matrix
{
	private double[,] matrix;
	private int x, y;

	public Matrix(Document[] documents, Dictionary<string, double> idf)
	{
		this.x = 0;
		foreach(Document document in documents)
		{
			int c = document.GetWordCount();
			if(c > this.x) this.x = c;
		}
		this.y = documents.Length;
		this.matrix = new double[this.y,this.x];

		for(int i = 0; i < this.y; i++)
		{
			Vector v = documents[i].GetVector(idf);
			for(int j = 0; j < v.Length; j++)
			{
				this.matrix[i,j] = v[j];
			}
		}

		NormalizeMatrix();
	}

	public void NormalizeMatrix()
	{
		double[] rowNorms = new double[this.y];
		for(int i = 0; i < this.y; i++)
		{
			double rowNorm = 0;
			for(int j = 0; j < this.x; j++)
			{
				rowNorm += Math.Pow(this.matrix[i,j], 2);
			}
			rowNorms[i] = Math.Sqrt(rowNorm);
		}

		for(int i = 0; i < this.y; i++)
		{
			for(int j = 0; j < this.x; j++)
			{
				this.matrix[i,j] /= rowNorms[i];
			}
		}
	}
}