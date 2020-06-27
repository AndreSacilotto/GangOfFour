using System;

/// <summary>
/// Você tem uma classe que diz quando a verdadeira classe irá realizar certa atividade.
/// Proxy é parecido com facade e adapter.
/// </summary>
public sealed class Proxy : IDesingPattern
{
	public void RunPattern()
	{
        ProxyDemo.IService service = new ProxyDemo.Proxy( 
            new ProxyDemo.IService[] { new ProxyDemo.RealService(), new ProxyDemo.RealService2() } );
        service.Request();
    }
}

public class ProxyDemo
{
    public interface IService
    {
        void Request();
    }

    // Real Object
    public class RealService : IService
    {
		public void Request() => Console.WriteLine("Real1: Handling Request");
	}
    public class RealService2 : IService
    {
        public void Request() => Console.WriteLine("Real2: Handling Request");
    }

    // Proxy Object
    public class Proxy : IService
    {
        private readonly IService[] services;

		public Proxy(IService[] services)
		{
            this.services = services;
		}

		public void Request()
		{
            foreach (var x in services)
                x.Request();
        }
	}
}
