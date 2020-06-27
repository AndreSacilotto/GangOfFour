using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// You make a generic way to interact between varius types of objects.
/// </summary>
/// The C# already have this implemented named IEnumerator.

public sealed class Iterator : IDesingPattern
{
	public void RunPattern()
    {
        var collection = new IteratorDemo.WordsCollection();
        collection.AddItem("First");
        collection.AddItem("Second");
        collection.AddItem("Third");

        Console.WriteLine("Straight traversal:");

        foreach (var element in collection)
            Console.WriteLine(element);

        Console.WriteLine("\nReverse traversal:");

        collection.ReverseDirection();

        foreach (var x in collection)
            Console.WriteLine(x);

    }
}

public class IteratorDemo
{
    public abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current;

        public abstract int Key();
		public abstract object Current { get; }

		public abstract bool MoveNext();
        public abstract void Reset();
    }

    public abstract class IteratorAggregate : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }

    public class AlphabeticalOrderIterator : Iterator
    {
        private readonly WordsCollection collection;
        private readonly bool reverse = false;
        private int position = -1;

        public AlphabeticalOrderIterator(WordsCollection collection, bool reverse = false)
        {
            this.collection = collection;
            this.reverse = reverse;
            if (reverse)
                position = collection.Collection.Count;
        }

		public override object Current => collection.Collection[position];

		public override int Key() => position;

		public override bool MoveNext()
        {
            int updatedPosition = position + (reverse ? -1 : 1);

            if (updatedPosition >= 0 && updatedPosition < collection.Collection.Count)
            {
                position = updatedPosition;
                return true;
            }
            return false;
        }

		public override void Reset() => position = reverse ? collection.Collection.Count - 1 : 0;
	}

    public class WordsCollection : IteratorAggregate
    {
		public List<string> Collection { get; } = new List<string>();

        bool direction = false;

		public void ReverseDirection() => direction = !direction;

        public void AddItem(string item)
        {
            Collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new AlphabeticalOrderIterator(this, direction);
        }
    }
}
