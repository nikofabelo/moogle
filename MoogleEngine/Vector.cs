namespace MoogleEngine;

public class Vector
{
	private Dictionary<string, double> tf;
	private double[] terms;

	public Vector(Dictionary<string, double> tf)
	{
		Debug.TravelDictValues(tf);
		terms = new double[tf.Count];
		for(int i = 0; i < tf.Count; i++)
			terms[i] = Dataset.GetIDF(
				tf.ElementAt(i).Key)*
				tf.ElementAt(i).Value;
		Debug.TravelArray(terms);
	}
}