using System;

/// <summary>
/// Você cria uma corrente de classes onde uma a uma vai tentando
/// solucionar um problema até que alguma consiga solucionar.
/// </summary>
/// Works like a liked list

public sealed class ChainOfResponsibility : IDesingPattern
{
	public void RunPattern()
	{
        var monkey = new ChainOfResponsibilityDemo.MonkeyHandler();
        var squirrel = new ChainOfResponsibilityDemo.SquirrelHandler();
        var dog = new ChainOfResponsibilityDemo.DogHandler();

        // Set the Chain
        monkey.SetNext(dog).SetNext(squirrel);

        foreach (var food in new string[] { "Nut", "Banana", "Cup of coffee" })
        {
            var result = monkey.Handle(food);
            Console.Write(result != null ? result.ToString() : $"{food} was left untouched\n");
        }
    }
}

public class ChainOfResponsibilityDemo
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        object Handle(object request);
    }

    public abstract class AbstractHandler : IHandler
    {
        private IHandler nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            nextHandler = handler;
            return handler;
        }

		public virtual object Handle(object request) => nextHandler?.Handle(request);
	}

    public class MonkeyHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
			return (request as string) == "Banana" ? 
                $"Monkey: Eat the {request}.\n" : base.Handle(request);
		}
    }

    public class SquirrelHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
			return request.ToString() == "Nut" ? 
                $"Squirrel: Eat the {request}.\n" : base.Handle(request);
		}
    }

    public class DogHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
			return request.ToString() == "MeatBall" ? 
                $"Dog: Eat the {request}.\n" : base.Handle(request);
		}
    }
}
