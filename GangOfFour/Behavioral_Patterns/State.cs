using System;

/// <summary>
/// O objetivo do padrão State é fazer com que uma classe consiga operar de formas,
/// sem a nessecidade de alterar a classe em si.
/// </summary>
public sealed class State : IDesingPattern
{
	public void RunPattern()
	{
        var context = new StateDemo.StateContext(new StateDemo.LowerCaseState());

        var arr = new string[] { "Monday", "Tuesday", "Wednesday", 
            "Thursday", "Friday", "Saturday", "Sunday" };

		foreach (var x in arr)
            context.WriteName(x);
    }
}

public class StateDemo
{
    public interface IState
    {
        StateContext Context { get; set; }
        void WriteName(string name);
    }

    public class LowerCaseState : IState
    {
		public StateContext Context { get; set; }

		public void WriteName(string name)
        {
            Console.WriteLine(name.ToLower());
            Context.State = new MultipleUpperCaseState();
        }
	}
    public class MultipleUpperCaseState : IState
    {
        int count = 0;

        public StateContext Context { get; set; }

        public void WriteName(string name)
        {
            Console.WriteLine(name.ToUpper());
            if (++count == 2)
                Context.State = new LowerCaseState();
        }
    }

    public class StateContext
    {
		private IState state;
		public IState State { get => state; set => SetState(value); }

        public StateContext(IState state) => SetState(state);

        public void SetState(IState state)
		{
            this.state = state;
            state.Context = this;
        }

		public void WriteName(string name) => State.WriteName(name);
	}
}