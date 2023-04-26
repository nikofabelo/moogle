namespace MoogleEngine;

public class Vector
{
	private double norm = 0;
	private double[] items;

	public Vector(Dictionary<string, int> tf, Dictionary<string, double> idf)
	{
		this.items = new double[tf.Count];
		for(int i = 0; i < Length; i++)
			this.items[i] = tf.ElementAt(i).Value*idf[tf.ElementAt(i).Key];
		Normalize();
	}

	private void CalculateNorm()
	{
		for(int i = 0; i < Length; i++)
		{
			this.norm += Math.Pow(this.items[i], 2);
		}
		this.norm = Math.Sqrt(this.norm);
	}

	private void Normalize()
	{
		CalculateNorm();
		// TODO norm == 0 < Query empty?
		for(int i = 0; i < Length; i++)
		{
			this.items[i] /= Norm;
		}
	}

	public double Norm { get { return this.norm; } }

	public double this[int i] { get { return this.items[i]; } }

	public double[] AsDouble() { return this.items; } // XXX

	public int Length { get { return this.items.Length; } }
}