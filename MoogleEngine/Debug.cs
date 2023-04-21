namespace MoogleEngine;

public class Debug
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

	public static void TravelDict(Dictionary<string, double> d)
	{
		foreach(string key in d.Keys)
			Console.WriteLine("{0}:\t{1}", key, d[key]);
	}

	public static void TravelDictValues(Dictionary<string, double>  d)
	{
		foreach(double a in d.Values)
			Console.WriteLine(a);
	}
}