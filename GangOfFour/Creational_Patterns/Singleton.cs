using System;
using System.Data.SqlTypes;


/// <summary>
/// Assegurar que somente uma instancia da classe exista.
/// https://csharpindepth.com/Articles/Singleton
/// </summary>

public sealed class Singleton : IDesingPattern
{
	public void RunPattern()
	{
        SingletonDemo.Instance.testVar = 2;
        // Metodo nunca antes instanciado é chamado com sucesso
        Console.WriteLine(SingletonDemo.Instance.testVar);
	}
}

public class SingletonDemo : SingletonSimple<SingletonDemo>
{
    public int testVar;
}

public class SingletonSimple<T> : IDisposable where T : class, new()
{
    // NOT THREAD-SAFE
    protected SingletonSimple() { }

    private static T instance;

    public static T Instance 
    {
        get 
        {
            if (instance == null)
				instance = new T();
            return instance;
        }
    }

	public void Dispose()
	{
        if (this == instance)
            instance = null;
    }
}

public class SingletonThreadSafe
{
    private SingletonThreadSafe() { }

    private static SingletonThreadSafe instance;

    private static readonly object obj = new object();

    public static SingletonThreadSafe Instance
    {
        get
        {
            if (instance == null)
            {
                lock (obj)
                {
                    if (instance == null)
                        instance = new SingletonThreadSafe();
                }
            }
            return instance;
        }
    }

}

public class SingletonLazy
{
    // Only C# but thread-safe
    private SingletonLazy() { }

    private static readonly Lazy<SingletonLazy> lazy = 
        new Lazy<SingletonLazy> (() => new SingletonLazy());

    public static SingletonLazy Instance { get { return lazy.Value; } }

}