using System;
using System.Collections.Generic;

/// <summary>
/// O interpreter serve para criar classes que ajudem o programa
/// a interretar uma informação de uma maneira diferente do que concedida.
/// </summary>
public sealed class Interpreter : IDesingPattern
{
    public void RunPattern()
    {
        string roman = "MCMXXVIII";
        var context = new InterpreterDemo.Context(roman);

		var tree = new List<InterpreterDemo.Expression>
		{
            new InterpreterDemo.ThousandExpression(),
            new InterpreterDemo.HundredExpression(),
            new InterpreterDemo.TenExpression(),
			new InterpreterDemo.OneExpression()
		};

		foreach (var exp in tree)
            exp.Interpret(context);

        Console.WriteLine($"{roman} = {context.Output}");
    }
}

public class InterpreterDemo
{
    public class Context
    {
		public Context(string input) => Input = input;

		public string Input { get; set; }
		public int Output { get; set; }
	}

    public abstract class Expression
    {
        public void Interpret(Context context)
        {
            if (context.Input.Length == 0)
                return;

            if (context.Input.StartsWith(Nine))
            {
                context.Output += (9 * Multiplier);
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Four))
            {
                context.Output += (4 * Multiplier);
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Five))
            {
                context.Output += (5 * Multiplier);
                context.Input = context.Input.Substring(1);
            }

            while (context.Input.StartsWith(One))
            {
                context.Output += (1 * Multiplier);
                context.Input = context.Input.Substring(1);
            }
        }

		public abstract string One { get; }

		public abstract string Four { get; }

		public abstract string Five { get; }

		public abstract string Nine { get; }

		public abstract int Multiplier { get; }
	}

    public class ThousandExpression : Expression
    {
		public override string One => "M"; 
        public override string Four => " "; 
        public override string Five => " ";
        public override string Nine => " "; 
        public override int Multiplier => 1000;
	}

    public class HundredExpression : Expression

    {
		public override string One => "C";
		public override string Four => "CD";
		public override string Five => "D";
		public override string Nine => "CM";
		public override int Multiplier => 100;
	}

    public class TenExpression : Expression
    {
		public override string One => "X"; 
        public override string Four => "XL";
		public override string Five => "L"; 
        public override string Nine => "XC";
        public override int Multiplier => 10;
	}

    public class OneExpression : Expression
    {
		public override string One => "I"; 
        public override string Four => "IV";
		public override string Five => "V";
		public override string Nine => "IX"; 
        public override int Multiplier => 1;
	}
}

