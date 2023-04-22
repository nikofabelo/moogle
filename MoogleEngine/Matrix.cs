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
	}

	public double[] NormalizeMatrix()
	{
		Console.WriteLine("OK");
        // Example document-term matrix
        double[,] docTermMatrix = new double[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        // Compute the Euclidean length of each row vector
        double[] rowNorms = new double[docTermMatrix.GetLength(0)];
        for (int i = 0; i < docTermMatrix.GetLength(0); i++)
        {
            double rowNorm = 0;
            for (int j = 0; j < docTermMatrix.GetLength(1); j++)
            {
                rowNorm += Math.Pow(docTermMatrix[i, j], 2);
            }
            rowNorms[i] = Math.Sqrt(rowNorm);
        }

        // Divide each row vector by its Euclidean length to normalize it
        for (int i = 0; i < docTermMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < docTermMatrix.GetLength(1); j++)
            {
                docTermMatrix[i, j] /= rowNorms[i];
            }
        }

        // Print the normalized matrix
        for (int i = 0; i < docTermMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < docTermMatrix.GetLength(1); j++)
            {
                Console.Write($"{docTermMatrix[i, j]:f2}\t");
            }
            Console.WriteLine();
        }

		return new double[0];
	}
}