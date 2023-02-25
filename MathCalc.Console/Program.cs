using Frognar.MathCalc;

if (args.Length < 1)
    throw new Exception("Expression needed!");

Calculator calculator = new();
Console.WriteLine(args[0] + " = " + calculator.Evaluate(args[0]));