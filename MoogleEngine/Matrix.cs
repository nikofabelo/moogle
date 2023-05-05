namespace MoogleEngine;

public class Matrix
{
	private Vector[] vectors;

	public Matrix(Document[] documents)
	{
		this.vectors = new Vector[documents.Length];
		for(int i = 0; i < this.vectors.Length; i++)
		{
			this.vectors[i] = documents[i].GetVector();
		}
	}

	public Vector this[int i] { get { return this.vectors[i]; } }
}