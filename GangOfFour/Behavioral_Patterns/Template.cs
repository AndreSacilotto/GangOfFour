using System;

/// <summary>
/// O objectivo do padrão Template é fazer com que várias classes que possuem
/// código repetido, não nessecitem repetir ao criar uma classe pai que implementa
/// o código repetido.
/// </summary>
/// In true can't say the difference between this and well applyed polymorphism
public sealed class Template : IDesingPattern
{
	public void RunPattern()
	{
		Console.WriteLine("Same client code can work with different subclasses:");
		var cc1 = new TemplateDemo.ConcreteClass1();
		cc1.TemplateMethod();

		Console.WriteLine();

		Console.WriteLine("Same client code can work with different subclasses:");
		var cc2 = new TemplateDemo.ConcreteClass2();
		cc2.TemplateMethod();
	}
}

public class TemplateDemo
{
    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            this.BaseOperation1();
            this.RequiredOperations1();
            this.BaseOperation2();
            this.Hook1();
            this.RequiredOperation2();
            this.BaseOperation3();
            this.Hook2();
        }

		protected void BaseOperation1() => 
            Console.WriteLine("AbstractClass says: I am doing the bulk of the work");

		protected void BaseOperation2() => 
            Console.WriteLine("AbstractClass says: But I let subclasses override some operations");

		protected void BaseOperation3() => 
            Console.WriteLine("AbstractClass says: But I am doing the bulk of the work anyway");

		protected abstract void RequiredOperations1();
        protected abstract void RequiredOperation2();

        //OPTIONAL
        protected virtual void Hook1() { }
        protected virtual void Hook2() { }
    }

    public class ConcreteClass1 : AbstractClass
    {
		protected override void RequiredOperations1() => 
            Console.WriteLine("ConcreteClass1 says: Implemented Operation1");

		protected override void RequiredOperation2() => 
            Console.WriteLine("ConcreteClass1 says: Implemented Operation2");
	}

    public class ConcreteClass2 : AbstractClass
    {
		protected override void RequiredOperations1() => 
            Console.WriteLine("ConcreteClass2 says: Implemented Operation1");

		protected override void RequiredOperation2() => 
            Console.WriteLine("ConcreteClass2 says: Implemented Operation2");

		protected override void Hook1() => 
            Console.WriteLine("ConcreteClass2 says: Overridden Hook1");
	}
}
