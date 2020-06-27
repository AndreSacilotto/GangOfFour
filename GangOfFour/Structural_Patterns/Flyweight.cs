using System;

/// <summary>
/// Flywheigs is a pattern that you trade CPU for less RAM use.
/// You do that making the vars external to the class that actual use the value
/// </summary>
public sealed class Flyweight : IDesingPattern
{
	public void RunPattern()
	{
        var tree = new FlyweightDemo.MyTreeObject();
        Console.WriteLine(tree.Name);
    }
}

public class FlyweightDemo
{
    class FlyWeight
    {
        public string TreeType { get; set; }
        public string TreeName { get; set; }
        public string[] TreeColors { get; set; }
    }

    static class FlyWeightPointer
    {
        public static FlyWeight Fly => new FlyWeight
        {
            TreeType = "Pinho",
            TreeName = "Azuru",
            TreeColors = new string[] { "Blue", "Green", "White"}
        };
    }

    public class MyTreeObject
    {
        public string Name => FlyWeightPointer.Fly.TreeName;
		public string[] CharacterColors => FlyWeightPointer.Fly.TreeColors;

        public int posX, posY;
	}
}
