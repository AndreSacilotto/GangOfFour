using System;
using System.Linq;

class Program
{
	static void Main()
	{
		int select = -1;

		var types = AppDomain.CurrentDomain.GetAssemblies()
			.SelectMany(s => s.GetTypes())
			.Where(p => typeof(IDesingPattern).IsAssignableFrom(p) 
			&& p != typeof(IDesingPattern)).ToList();

		start:
		for (int i = 0; i < types.Count; i++)
			Console.WriteLine($"{i,-4} : {types[i].FullName}");

		if (select < 0 || select > types.Count)
		{
			if (ConvertInRange(Console.ReadLine(), types.Count, out var ret))
				select = ret;
			else
			{
				Console.Clear();
				goto start;
			}
		}

		var dp = (IDesingPattern)Activator.CreateInstance(types[select]);
		Console.WriteLine($"{dp} Created\n");
		dp.RunPattern();
	}

	static bool ConvertInRange(string str, int max, out int value) 
	{
		if (int.TryParse(str, out var ret) && ret >= 0 && ret < max)
		{
			value = ret;
			return true;
		}
		else
		{
			value = -1;
			return false;
		}
	}

}

interface IDesingPattern 
{
	void RunPattern();
}