namespace MoogleEngine.Math;

public class Vector
{
	private double[] items;

	public Vector(double[] items)
	{
		this.items = items;
	}

	public double this[int i] { get { return this.items[i]; } }

	public int Length { get { return this.items.Length; } }

	public static Vector operator +(Vector v, Vector w)
	{
		if(v.Length != w.Length)
			throw new ArgumentException("Vectors have different length.");
		double[] t = new double[v.Length];
		for(int i = 0; i < v.Length; i++)
		{
			t[i] = v[i]+w[i];
		}
		return new Vector(t);
	}

	public static double operator *(Vector v, Vector w)
	{
		if(v.Length != w.Length)
			throw new ArgumentException("Vectors have different length.");
		double s = 0;
		for(int i = 0; i < v.Length; i++)
		{
			s += v[i]*w[i];
		}
		return s;
	}

	public static Vector operator *(Vector v, double s)
	{
		double[] t = new double[v.Length];
		for(int i = 0; i < v.Length; i++)
		{
			t[i] = v[i]*s;
		}
		return new Vector(t);
	}

	public static Vector operator -(Vector v, Vector w)
	{
		return v+(w*-1);
	}
}