namespace MoogleEngine;

public class Debug
{
	public static void Print(string s)
	{
		Console.WriteLine(s);
	}

	public static void TravelArray(string[] a)
	{
		foreach(string s in a)
			Console.WriteLine(s);
	}

	public static void TravelDict(Dictionary<string, float> d)
	{
		foreach(string key in d.Keys)
			Console.WriteLine("{0}: {1}", key, d[key]);
	}
}