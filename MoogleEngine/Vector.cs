namespace MoogleEngine;

public class Vector
{
	private double[] terms;

	public Vector(Dictionary<string, double> tf, Dictionary<string, double> idf)
	{
		this.terms = new double[tf.Count];
		for(int i = 0; i < tf.Count; i++)
		{
			this.terms[i] = tf.ElementAt(i).Value*idf[tf.ElementAt(i).Key];
		}
		Normalize();
	}

	public double CalculateNorm()
	{
		double norm = 0;
		for(int j = 0; j < Length; j++)
		{
			norm += Math.Pow(this.terms[j], 2);
		}
		norm = Math.Sqrt(norm);
		return norm;
	}

	public double this[int i] { get { return terms[i]; } }

	public double[] AsDouble() { return terms; } // TODO

	public int Length { get { return terms.Length; } }

	public void Normalize()
	{
		double norm = CalculateNorm();
		// norm == 0 TODO
		for(int j = 0; j < Length; j++)
		{
			terms[j] /= norm;
		}
	}
}