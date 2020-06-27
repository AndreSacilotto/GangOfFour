using System;

/// <summary>
/// Esconde classes em que o usario não deve ter acesso, ou
/// compila várias funcionaliadades que juntas tornan-se uma.
/// </summary>
public sealed class Facade : IDesingPattern
{
	public void RunPattern()
	{
        var fachada = new FacadeDemo.Facade();
        //First System Call
        fachada.Operation1();
        //Second System Call
        fachada.Operation2();
    }
}

public class FacadeDemo
{
    class SubsystemA
    {
		public string OperationA1 => "Subsystem A, Method A1\n";
		public string OperationA2 => "Subsystem A, Method A2\n";
	}

    class SubsystemB
    {
		public string OperationB1 => "Subsystem B, Method B1\n";
		public string OperationB2 => "Subsystem B, Method B2\n";
	}

    class SubsystemC
    {
		public string OperationC1 => "Subsystem C, Method C1\n";
		public string OperationC2 => "Subsystem C, Method C2\n";
	}

    public class Facade
    {
        private readonly SubsystemA a = new SubsystemA();
        private readonly SubsystemB b = new SubsystemB();
        private readonly SubsystemC c = new SubsystemC();
        public void Operation1()
        {
            Console.WriteLine("Operation 1\n" +
                a.OperationA1+
                b.OperationB1+
                c.OperationC1);
        }
        public void Operation2()
        {
            Console.WriteLine("Operation 2\n" +
                a.OperationA2+
                b.OperationB2+
                c.OperationC2);
        }
    }
}
