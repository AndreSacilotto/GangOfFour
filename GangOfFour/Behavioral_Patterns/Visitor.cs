using System;
using System.Collections.Generic;

/// <summary>
/// O objectivo do padrão Visitor, é criar um visitador para cada classe.
/// Permitindo assim que ele execute alguma operação realacionada a classe,
/// sem a classe que está sendo visitada saber ela somente deve aceitar o pedido.
/// </summary>
/// They have 2 types of implemantation the static and dynamic
/// One of most complicated pattern of GOF
public sealed class Visitor : IDesingPattern
{
	public void RunPattern()
	{
        var components = new List<VisitorDemo.IComponent>()
        {
            new VisitorDemo.ConcreteComponentA(),
            new VisitorDemo.ConcreteComponentB()
        };

        Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
        var visitor1 = new VisitorDemo.ConcreteVisitor1();
        foreach (var x in components)
            x.Accept(visitor1);

        Console.WriteLine();

        Console.WriteLine("It allows the same client code to work with different types of visitors:");
        var visitor2 = new VisitorDemo.ConcreteVisitor2();
        foreach (var x in components)
            x.Accept(visitor2);

    }
}

public class VisitorDemo
{
    public interface IComponent
    {
        void Accept(IVisitor visitor);
    }

    public class ConcreteComponentA : IComponent
    {
		public void Accept(IVisitor visitor) => visitor.VisitConcreteComponentA(this);
		public string ExclusiveMethodOfA() => "A";
	}

    public class ConcreteComponentB : IComponent
    {
		public void Accept(IVisitor visitor) => visitor.VisitConcreteComponentB(this);
		public string ExclusiveMethodOfB() => "B";
	}

    public interface IVisitor
    {
        void VisitConcreteComponentA(ConcreteComponentA element);
        void VisitConcreteComponentB(ConcreteComponentB element);
    }

    public class ConcreteVisitor1 : IVisitor
    {
		public void VisitConcreteComponentA(ConcreteComponentA element) => 
            Console.WriteLine(element.ExclusiveMethodOfA() + " + ConcreteVisitor1");

		public void VisitConcreteComponentB(ConcreteComponentB element) => 
            Console.WriteLine(element.ExclusiveMethodOfB() + " + ConcreteVisitor1");
	}

    public class ConcreteVisitor2 : IVisitor
    {
		public void VisitConcreteComponentA(ConcreteComponentA element) => 
            Console.WriteLine(element.ExclusiveMethodOfA() + " + ConcreteVisitor2");

		public void VisitConcreteComponentB(ConcreteComponentB element) => 
            Console.WriteLine(element.ExclusiveMethodOfB() + " + ConcreteVisitor2");
	}
}