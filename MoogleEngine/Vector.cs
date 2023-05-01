namespace MoogleEngine;

public class Vector
{
	private double norm = 0;
	private double[] items;

	public Vector(Dictionary<string, double> tf, Dictionary<string, double> idf)
	{
		this.items = new double[idf.Count];
		for(int i = 0; i < this.items.Length; i++)
		{
			KeyValuePair<string, double> pair = idf.ElementAt(i);
			this.items[i] = (tf.TryGetValue(
				pair.Key, out double value) ? value : 0)*pair.Value;
		}
		CalculateNorm();
	}

	private void CalculateNorm()
	{
		for(int i = 0; i < this.items.Length; i++)
		{
			this.norm += Math.Pow(this.items[i], 2);
		}
		this.norm = Math.Sqrt(this.norm);
	}

	public double Norm { get { return this.norm; } }

	public double this[int i] { get { return this.items[i]; } }

	public int Length { get { return this.items.Length; } }
}