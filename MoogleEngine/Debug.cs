namespace MoogleEngine;

public static class Debug
{
	public static bool HasWrong(Dictionary<string, double> d)
	{
		foreach(var v in d.Values)
		{
			if(IsWrong(v))
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsWrong(double d)
	{
		return (double.IsInfinity(d) || double.IsNaN(d)) ? true : false;
	}

	public static void TravelArray(double[] a)
	{
		foreach(double d in a)
			Console.WriteLine(d);
	}

	public static void TravelArray(string[] a)
	{
		foreach(string s in a)
			Console.WriteLine(s);
	}

	public static void TravelDict(Dictionary<string, double> d)
	{
		foreach(string key in d.Keys)
			Console.WriteLine("{0}:\n\t{1}", key, d[key]);
	}

	public static void TravelDict(Dictionary<double, Document> d)
	{
		foreach(double key in d.Keys)
			Console.WriteLine("{0}:\n\t{1}", key, d[key].Name);
	}

	public static void TravelVector(Vector v)
	{
		for(int i = 0; i < v.Length; i++)
		{
			Console.WriteLine(v[i]);
		}
	}
}