namespace MoogleEngine;

public class Vector
{
	private double[] terms = new double[]{};

	public Vector(Dictionary<string, double> tf, Dictionary<string, double> idf)
	{
		this.terms = new double[tf.Count];
		for(int i = 0; i < tf.Count; i++)
		{
			this.terms[i] = tf.ElementAt(i).Value*idf[tf.ElementAt(i).Key];
		}
	}

	public int Length { get { return terms.Length; } }

	public double this[int i] { get { return terms[i]; } }

	public void Normalize()
	{
		double norm = 0;
		for(int j = 0; j < Length; j++)
		{
			norm += Math.Pow(this.terms[j], 2);
		}
		norm = Math.Sqrt(norm);

		// norm => 0
		for(int j = 0; j < Length; j++)
		{
			terms[j] /= norm;
		}
	}
}