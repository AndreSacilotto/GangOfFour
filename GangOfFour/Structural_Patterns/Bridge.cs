using System;

/// <summary>
/// Você cria uma classe que possue uma refência gênerica a outra classe.
/// </summary>
public sealed class Bridge : IDesingPattern
{
	public void RunPattern()
	{
        BridgeDemo.IBridge pa = new BridgeDemo.PlataformA();
        BridgeDemo.IBridge pb = new BridgeDemo.PlataformB();
		var ab = new BridgeDemo.AbstractBridge
		{
			Bridge = pa
		};
		ab.CallMethod1();

        ab.Bridge = pb;
        ab.CallMethod1();
    }
}

public class BridgeDemo
{
    public interface IBridge
    {
        void Function1();
        void Function2();
    }

    //Cor B
    public class PlataformA : IBridge
    {
        public void Function1() => Console.WriteLine("PlataformA - F1");
        public void Function2() => Console.WriteLine("PlataformA - F2");
    }

    //Cor A
    public class PlataformB : IBridge
    {
        public void Function1() => Console.WriteLine("PlataformB - F1");
        public void Function2() => Console.WriteLine("PlataformB - F2");
    }

    //Forma Base
    public class AbstractBridge
    {
        public IBridge Bridge { get; set; }

        public void CallMethod1()
        {
            Bridge.Function1();
        }

        public void CallMethod2()
        {
            Bridge.Function2();
        }
    }
}
