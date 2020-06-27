using System;

/// <summary>
/// Utilizada quando você possue uma classe não pode ser alterada
/// porem a alteração é nessesária.
/// </summary>
public sealed class Adapter : IDesingPattern
{
	public void RunPattern()
	{
        var inputA = new AdapterDemo.InputA();
        var inputB = new AdapterDemo.InputB();

        inputA.Connect();
        inputB.Connect();

        var target = (AdapterDemo.InputB)new AdapterDemo.Adapter_AToB(inputA);
        target.Connect();
    }
}

public class AdapterDemo
{
    //Target - Can't Modify
    public class InputA
    {
        public virtual void Connect()
        {
            Console.WriteLine("Entrada tipo A");
        }
    }

    //Adaptee
    public class InputB
    {
        public virtual void Connect()
        {
            Console.WriteLine("Entrada tipo B");
        }
    }

    //Adapter
    public class Adapter_AToB : InputB
    {
        private readonly InputA inputA;

        public Adapter_AToB(InputA inputA) => this.inputA = inputA;

        public override void Connect()
        {
            Console.Write("I'm input B class, but ");
            inputA.Connect();
        }
    }
}
