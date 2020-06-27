using System;

/// <summary>
/// Permite a dissociação de um classe e sua ação, 
/// permitindo que várias classes possam utilizar a mesma ação.
/// Sua principal utilidade é criar deixar a subclasse se encarregar de criar o objeto
/// </summary>

public sealed class Factory : IDesingPattern
{
	public void RunPattern()
	{
		var c1 = FactoryDemo.Creator.Operation(FactoryDemo.ProductsList.P1);
		var c2 = FactoryDemo.Creator.Operation(FactoryDemo.ProductsList.P2);

		c1.DoStuff();
		c2.DoStuff();
	}
}

// Essa não é a classica implementação, é a minha impletação
public class FactoryDemo
{
	public class Product 
	{
		public virtual void DoStuff() { }
	}

	public class ProductA : Product
	{
		public string Item { get; private set; }
		public ProductA(string item) => Item = item;
		public override void DoStuff()
		{
			Console.WriteLine(Item);
		}
	}

	public class ProductB : Product
	{
		public int Item { get; private set; }
		public ProductB(int item) => Item = item;
		public override void DoStuff()
		{
			Console.WriteLine(Item * 10);
		}
	}

	public static class Creator
	{
		public static Product Operation(ProductsList p)
		{
			return p switch
			{
				ProductsList.P1 => new ProductA("Banana"),
				ProductsList.P2 => new ProductB(10),
				_ => null,
			};
		}
	}

	public enum ProductsList 
	{ 
		P1,
		P2
	}


}
