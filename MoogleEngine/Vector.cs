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
		Debug.TravelArray(terms);
	}

	public int Length { get { return terms.Length; }}
}