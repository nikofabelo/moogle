namespace MoogleEngine;

public class Vector
{
	private double[] items;

	public Vector(Dictionary<string, int> tf, Dictionary<string, double> idf)
	{
		this.items = new double[tf.Count];
		for(int i = 0; i < tf.Count; i++)
			this.items[i] = tf.ElementAt(i).Value*idf[tf.ElementAt(i).Key];
		Normalize();
	}

	private double CalculateNorm()
	{
		double norm = 0;
		for(int j = 0; j < Length; j++)
		{
			norm += Math.Pow(this.items[j], 2);
		}
		norm = Math.Sqrt(norm);
		return norm;
	}

	public double this[int i] { get { return this.items[i]; } }

	public double[] AsDouble() { return this.items; } // XXX

	public int Length { get { return this.items.Length; } }

	private void Normalize()
	{
		double norm = CalculateNorm();
		// TODO norm == 0
		for(int j = 0; j < Length; j++)
		{
			this.items[j] /= norm;
		}
	}
}