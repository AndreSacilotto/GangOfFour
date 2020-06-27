using System;

/// <summary>
/// O Prototype serve para clonar uma classe 
/// sem criar dependencias com a classe que a usa.
/// </summary>
/// C# alredy have the implementation of it (MemberwiseClone), but it's a shallow copy.
/// The also have the IClonable interface.
public sealed class Prototype : IDesingPattern
{
	public void RunPattern()
	{

		var inst = new PrototypeDemo(2);
		var clone = inst.Clone();

		Console.WriteLine(inst == clone);
		Console.WriteLine(inst.x == clone.x);
		Console.WriteLine(inst.demo == clone.demo);

	}
}

interface IPrototype<T>
{
	T Clone();
}

class PrototypeDemo : IPrototype<PrototypeDemo>
{
	public int x;
	public PrototypeDemoSub demo;

	public PrototypeDemo(int x)
	{
		this.x = x;
		demo = new PrototypeDemoSub();
	}

	public PrototypeDemo Clone()
	{
		var clone = (PrototypeDemo) MemberwiseClone();
		clone.x = x;
		clone.demo = demo?.Clone();
		return clone;
	}

	public class PrototypeDemoSub : IPrototype<PrototypeDemoSub>
	{
		public PrototypeDemoSub Clone()
		{
			return (PrototypeDemoSub) MemberwiseClone();
		}
	}
}
