namespace MoogleEngine;

public static class Debug
{
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

	public static void TravelDict(Dictionary<Document, double> d)
	{
		foreach(Document key in d.Keys)
			Console.WriteLine("{0}:\n\t{1}", key.Name, d[key]);
	}

	public static void TravelDict(Dictionary<string, double> d)
	{
		foreach(string key in d.Keys)
			Console.WriteLine("{0}:\n\t{1}", key, d[key]);
	}

	public static void TravelDict(Dictionary<string, int> d)
	{
		foreach(string key in d.Keys)
			Console.WriteLine("{0}:\n\t{1}", key, d[key]);
	}

	public static void TravelVector(Vector v)
	{
		for(int i = 0; i < v.Length; i++)
		{
			Console.WriteLine(v[i]);
		}
	}
}