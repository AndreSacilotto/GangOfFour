using System;

/// <summary>
/// Quando você possue uma classe que pode sofrer incrementos/upgrades
/// sendos essas melhorias chamadas de decorações. O que agregam valor a classe.
/// </summary>
/// Uma simples lista de objectos poderia fazer o mesmo papel
public sealed class Decorator : IDesingPattern
{
	public void RunPattern()
	{
        var item = new DecoratorDemo.Item();
        var item2 = new DecoratorDemo.ItemAcessory1(item);
        var item3 = new DecoratorDemo.ItemAcessory2(item2);

        Console.WriteLine("RESULT: " + item3.GetPrice());
    }
}

public class DecoratorDemo
{
    public interface IDecorator 
    {
        public int GetPrice();
    }

    public class Item : IDecorator
    {
        public int GetPrice() => 5;
    }

    public abstract class ItemDecorator : IDecorator
    {
        private IDecorator Decor { get; }

        public ItemDecorator(IDecorator decor) => Decor = decor;

        public virtual int GetPrice() => Decor.GetPrice();
    }

    public class ItemAcessory1 : ItemDecorator
    {
        public ItemAcessory1(IDecorator decor) : base(decor) { }

        public override int GetPrice() => base.GetPrice() * 2;
    }

    public class ItemAcessory2 : ItemDecorator
    {
        public ItemAcessory2(IDecorator decor) : base(decor) { }

        public override int GetPrice() => base.GetPrice() + 20;
    }

}
