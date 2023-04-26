namespace MoogleEngine;

public class Vector
{
	private double norm = 0;
	private double[] items;

	public Vector(Dictionary<string, double> tf, Dictionary<string, double> idf)
	{
		this.items = new double[tf.Count];
		for(int i = 0; i < Length; i++)
			this.items[i] = tf.ElementAt(i).Value*idf[tf.ElementAt(i).Key];
		Normalize();
	}

	private void CalculateNorm() // FIXME
	{
		for(int i = 0; i < Length; i++)
		{
			double item = this.items[i];
			if(item != 0)
			{
				this.norm += Math.Pow(item, 2);
			}
			else if (double.IsNaN(item))
			{
				Console.WriteLine("NaN value found at index {0}", i);
			}
		}
		Console.WriteLine(this.norm);
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