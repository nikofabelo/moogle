namespace MoogleEngine;

public class Vector
{
// 	private double norm = 0;
	private double[] items;

	public Vector(Dictionary<string, double> tf, Dictionary<string, double> idf)
	{
		this.items = new double[tf.Count];
		for(int i = 0; i < this.items.Length; i++)
		{
			KeyValuePair<string, double> pair = tf.ElementAt(i);
			this.items[i] = pair.Value*idf[pair.Key];
		}
		// Normalize();
	}

// 	private void CalculateNorm() // FIXME
// 	{
// 		for(int i = 0; i < Length; i++)
// 		{
// 			double item = this.items[i];
// 			// Console.WriteLine("item: {0}", item);
// 			if(item != 0)
// 			{
// 				this.norm += Math.Pow(item, 2);
// 				// Console.WriteLine("\tNorm: {0}", this.norm);
// 				// if(double.IsNaN(Norm)) break;
// 			}
// 			else if (double.IsNaN(item))
// 			{
// 				Console.WriteLine("NaN value found at index {0}", i);
// 			}
// 		}
// 		// Console.WriteLine(this.norm);
// 		// this.norm = Math.Sqrt(this.norm);
// 		Console.WriteLine(Norm);
// 	}

// 	private void Normalize()
// 	{
// 		CalculateNorm();
// 		// TODO norm == 0 < Query empty?
// 		for(int i = 0; i < Length; i++)
// 		{
// 			this.items[i] /= Norm;
// 		}
// 	}

// 	public double Norm { get { return this.norm; } }

// 	public double this[int i] { get { return this.items[i]; } }

// 	public double[] AsDouble() { return this.items; } // XXX
}