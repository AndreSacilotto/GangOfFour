using System;
using System.Collections.Generic;

/// <summary>
/// Separa classes de uma forma em que elas possam ser chamadas de forma recursiva.
/// Classes devem ser possível de serem dispostas em formato de tree.
/// </summary>
public sealed class Composite : IDesingPattern
{
    public void RunPattern()
    {
        //  root
        //  / \
        // b1  b2
        //      \
        //       b3

        var root = new CompositeDemo.Branch();
        var b1 = new CompositeDemo.Branch();
        var b2 = new CompositeDemo.Branch();
        var b3 = new CompositeDemo.Branch();

        root.Add(b1);
        root.Add(b2);
        b2.Add(b3);

        b1.Add(new CompositeDemo.Leaf(2));
        b2.Add(new CompositeDemo.Leaf(2));
        b3.Add(new CompositeDemo.Leaf(2));

        Console.WriteLine(root.Call());
    }
}

public class CompositeDemo
{
    public interface IComponent
    {
        bool IsComposite { get; }
        virtual void Add(IComponent component) { }
        virtual void Remove(IComponent component) { }
        int Call();
    }

    public class Leaf : IComponent
    {
		readonly int value;
		public bool IsComposite { get; } = false;

		public Leaf(int value) => this.value = value;

        public int Call() => value;
	}

    public class Branch : IComponent
    {
        protected List<IComponent> children = new List<IComponent>();

        public bool IsComposite { get; } = true;

        public void Add(IComponent component) => children.Add(component);
        public void Remove(IComponent component) => children.Remove(component);

        public int Call()
        {
            int sum = 0;
			foreach (var x in children)
                sum += x.Call();

            return sum;
        }
    }
}

