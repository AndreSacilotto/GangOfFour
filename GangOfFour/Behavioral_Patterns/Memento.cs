using System;
using System.Collections.Generic;

/// <summary>
/// Seu objectivo é serializar um estado de uma classe. Permitindo undo/redo.
/// </summary>
/// Definitely not a good pattern, today we have better solutions.
public sealed class Memento : IDesingPattern
{
	public void RunPattern()
	{
        List<MementoDemo.Memento> savedStates = new List<MementoDemo.Memento>();

        var originator = new MementoDemo.Originator();
        originator.Set("State0");
        originator.Set("State1");
        savedStates.Add(originator.SaveToMemento());

        originator.Set("State2");
        savedStates.Add(originator.SaveToMemento());

        originator.Set("State3");
        originator.RestoreFromMemento(savedStates[1]);
    }
}

public class MementoDemo
{
    public class Originator
    {
        string state;

        public void Set(string state)
        {
            Console.WriteLine("Originator: Setting state to " + state);
            this.state = state;
        }

        public Memento SaveToMemento()
        {
            Console.WriteLine("Originator: Saving to Memento.");
            return new Memento(state);
        }

        public void RestoreFromMemento(Memento memento)
        {
            state = memento.SavedState;
            Console.WriteLine("Originator: State after restoring from Memento: " + state);
        }

    }

    public class Memento
    {
        public string SavedState { get; }

		public Memento(string stateToSave) => SavedState = stateToSave;
	}
}
