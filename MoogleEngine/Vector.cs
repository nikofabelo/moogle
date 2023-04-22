namespace MoogleEngine;

public class Vector
{
	public double[] terms = new double[]{};

	public Vector(Dictionary<string, double> tf, Dictionary<string, double> idf, int l)
	{
		if(l == 0) this.terms = new double[tf.Count];
		else this.terms = new double[l];
		for(int i = 0; i < tf.Count; i++)
		{
			this.terms[i] = tf.ElementAt(i).Value*idf[tf.ElementAt(i).Key];
		}
		for(int i = tf.Count; i < l; i++)
		{
			terms[i] = 0;
		}
	}

	public int Length { get { return terms.Length; }}

	public double this[int i]
	{
		get { return terms[i]; }
	}
}