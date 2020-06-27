using System;

/// <summary>
/// Mediator é uma classe que busca controlar todas as interações entre 2 ou mais classes.
/// </summary>
public sealed class Mediator : IDesingPattern
{
	public void RunPattern()
	{
        var p1 = new MediatorDemo.Person("Cay");
        var p2 = new MediatorDemo.Person("Luis");

        var med = new MediatorDemo.Mediator();
        p1.Mediator = med;
        p2.Mediator = med;

        p1.Send("Banana is good");
        p2.Send("Lizard is bad");
    }
}

public class MediatorDemo
{
    public delegate void MessageReceivedEventHandler(string message, string sender);

    public class Mediator
    {
        public event MessageReceivedEventHandler MessageReceived;
        public void SendMessage(string message, string sender)
        {
            if (MessageReceived != null)
            {
                Console.WriteLine("Sending '{0}' from {1}", message, sender);
                MessageReceived(message, sender);
            }
        }
    }

    public class Person
    {
        public string Name { get; }

        private Mediator mediator;
        public Mediator Mediator 
        {
            get => mediator;
            set 
            {
                if (mediator != null)
                    mediator.MessageReceived -= new MessageReceivedEventHandler(Receive);
                mediator = value;
                mediator.MessageReceived += new MessageReceivedEventHandler(Receive);
            }         
        }

		public Person(string name) => Name = name;

		public void Receive(string message, string sender)
        {
            if (sender != Name)
                Console.WriteLine("{0} received '{1}' from {2}", Name, message, sender);
        }

		public void Send(string message) => Mediator.SendMessage(message, Name);
	}
}
