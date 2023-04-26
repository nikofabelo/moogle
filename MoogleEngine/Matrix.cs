namespace MoogleEngine;

public class Matrix
{
	private Vector[] vectors;

	public Matrix(Document[] documents, Dictionary<string, double> corpusIDF)
	{
		this.vectors = new Vector[documents.Length];
		for(int i = 0; i < Length; i++)
			this.vectors[i] = documents[i].GetVector(corpusIDF);
	}

	public Vector this[int i] { get { return this.vectors[i]; } }

	public double[][] AsDoubles() // XXX
	{
		double[][] vectors = new double[Length][];
		for(int i = 0; i < Length; i++)
		{
			vectors[i] = this.vectors[i].AsDouble();
		}
		return vectors;
	}

	public int Length { get { return this.vectors.Length; } }
}