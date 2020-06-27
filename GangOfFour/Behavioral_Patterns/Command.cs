using System;

/// <summary>
/// Quando existem várias classes que nessecitam desenpenhar a mesma função você
/// pode transforma o metodo que essa classe usa em comandos. Criando uma camada de
/// abstração entre uma classe e outra.
/// </summary>
public sealed class Command : IDesingPattern
{
	public void RunPattern()
	{
        var invoker = new CommandDemo.Invoker();
        invoker.SetOnStart(new CommandDemo.SimpleCommand("Say Hi!"));
        var anyClass = new CommandDemo.AnyClass();
        invoker.SetOnFinish(new CommandDemo.ComplexCommand(anyClass, "Send email", "Save report"));

        invoker.DoSomethingImportant();
    }
}

public class CommandDemo
{
    public interface ICommand
    {
        void Execute();
    }

    public class SimpleCommand : ICommand
    {
        private readonly string payload;

        public SimpleCommand(string payload)
        {
            this.payload = payload;
        }

        public void Execute()
        {
            Console.WriteLine($"SimpleCommand: See, I can do simple things like printing ({this.payload})");
        }
    }

    public class ComplexCommand : ICommand
    {
        private readonly AnyClass receiver;
		private readonly string contextA, contextB;

		public ComplexCommand(AnyClass receiver, string a, string b)
        {
            this.receiver = receiver;
            contextA = a;
            contextB = b;
        }

        public void Execute()
        {
            Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object.");
            receiver.Make1(contextA);
            receiver.Make2(contextB);
        }
    }

    public class AnyClass
    {
		public void Make1(string a) => Console.WriteLine($"Receiver: Working on ({a}.)");
		public void Make2(string b) => Console.WriteLine($"Receiver: Also working on ({b}.)");
	}

    public class Invoker
    {
        private ICommand onStart;
        private ICommand onFinish;

		public void SetOnStart(ICommand command) => onStart = command;

		public void SetOnFinish(ICommand command) => onFinish = command;

		public void DoSomethingImportant()
        {
            onStart?.Execute();
            onFinish?.Execute();
        }
    }
}
