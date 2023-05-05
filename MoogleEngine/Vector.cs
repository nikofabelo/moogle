namespace MoogleEngine;

public class Vector
{
	private double norm = 0;
	private double[] items;

	public Vector(Dictionary<string, double> tf, Corpus corpus)
	{
		this.items = new double[corpus.DTF.Count];
		int i = 0;
		foreach(string key in corpus.DTF.Keys)
		{
			this.items[i] = (tf.TryGetValue(
				key, out double value) ? value : 0)*corpus.IDF[key];
			i++;
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