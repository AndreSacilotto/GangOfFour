using System;
using System.Collections.Generic;

/// <summary>
/// Abstrai grandes construtores, criando classes menores que podem 
/// construir o mesmo construtor sem fazer uma chamada gigantes
/// </summary>
public sealed class Builder : IDesingPattern
{
	public void RunPattern()
	{
        var builder = new BuilderDemo.ConcreteBuilderA();
        var director = new BuilderDemo.Director(builder);

        director.Build(BuilderDemo.Products.A | BuilderDemo.Products.C);
        var myProduct = builder.Product;
        myProduct.ListParts();
    }
}


// Decidi usar classe abstrata generica ao inves de interface.
// Diminuindo a quantidade de código redundante.
public class BuilderDemo
{
    public interface IBuilder
    {
        void Reset();
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
    }

    public class ConcreteBuilderA : IBuilder
    {
        public ConcreteBuilderA() => Reset();

		public Product Product { get; private set; }

        public void Reset() 
        {
            Product = new Product();
        }

		public void BuildPartA()
        {
            Product.Add("PartA_Done");
        }

        public void BuildPartB()
        {
            Product.Add("PartB_Done");
        }

        public void BuildPartC()
        {
            Product.Add("PartC_Done");
        }
    }

    public class Product
    {
        private readonly List<object> parts = new List<object>();

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void ListParts()
        {
            const string separator = ", ";
            string str = string.Empty;


            for (int i = 0; i < parts.Count; i++)
                str += parts[i] + separator;

            str = str.Remove(str.Length - separator.Length);

            Console.WriteLine(str);
        }
    }

    public class Director
    {
		public Director(IBuilder dirBuilder) => DirBuilder = dirBuilder;

		public IBuilder DirBuilder { get; private set; }

        public void Build(Products p)
        {
            DirBuilder.Reset();
            if (p.HasFlag(Products.A))
                DirBuilder.BuildPartA();
            if (p.HasFlag(Products.B))
                DirBuilder.BuildPartB();
            if (p.HasFlag(Products.C))
                DirBuilder.BuildPartC();
        }
    }

    [Flags]
    public enum Products 
    { 
        A,
        B,
        C
    }

}
