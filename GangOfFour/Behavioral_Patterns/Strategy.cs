using System;

/// <summary>
/// O padrão Strategy serve para que uma mesma classe possa acoplar diferentes classes,
/// onde cada classe irá implementar uma estrategia diferente para o problema proposto.
/// </summary>
/// The delegates of C# can do equal of this pattern.

public sealed class Strategy : IDesingPattern
{
	public void RunPattern()
	{
        var context = new StrategyDemo.Context();

        Console.WriteLine("Strategy is Normal Sorting");
        context.Strategy = new StrategyDemo.ConcreteStrategyA();
        context.DoWork();

        Console.WriteLine();

        Console.WriteLine("Strategy is Reverse Sorting");
        context.Strategy = new StrategyDemo.ConcreteStrategyB();
        context.DoWork();
    }
}

public class StrategyDemo
{
    public class Context
    {
        public IStrategy<string[]> Strategy { get; set; }

        public Context() { }

		public Context(IStrategy<string[]> strategy) => Strategy = strategy;

		public void DoWork()
        {
            if (Strategy == null)
                return;

            var result = Strategy.DoAlgorithm(new string[]{ "a", "b", "c", "d", "e" });

            string resultStr = string.Empty;
            foreach (var element in result)
                resultStr += element + ",";

            Console.WriteLine(resultStr);
        }
    }

    public interface IStrategy<T>
    {
        T DoAlgorithm(T data);
    }

    public class ConcreteStrategyA : IStrategy<string[]>
    {
        public string[] DoAlgorithm(string[] data)
        {
            var list = data;

            Array.Sort(list);

            return list;
        }
    }

    public class ConcreteStrategyB : IStrategy<string[]>
    {
        public string[] DoAlgorithm(string[] data)
        {
            var list = data;
            Array.Sort(list);
            Array.Reverse(list);

            return list;
        }
    }
}
