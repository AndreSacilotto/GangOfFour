using System;

/// <summary>
/// O padrão observer trabalha com observadores e um sujeito, o qual está encarregado
/// de notificar todos os observadores caso requisitado.
/// </summary>
/// It's so commom that microsoft have a page for them
/// https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ee817669(v=pandp.10)

public sealed class Observer : IDesingPattern
{
	public void RunPattern()
	{
        var subject = new ObserverDemo.Subject();

        var observerA = new ObserverDemo.Observer { Identifier = "A" };
        var observerB = new ObserverDemo.Observer { Identifier = "B" };

        subject.Update += observerA.Update;
        subject.Update += observerB.Update;

        subject.Notify();
    }
}

public class ObserverDemo
{
    public class Subject
    {
        public event Action Update;

        public void Notify() => Update?.Invoke();
    }

    public class Observer
    {
        public string Identifier { get; set; }

        public void Update() => Console.WriteLine($"My Identifier = {Identifier}");
    }
}
