namespace Frognar.MathCalc.Evaluators;

public static class EvaluateProvider
{
    public static Evaluator GetEvaluator(string symbol)
    {
        return new NegativeEvaluator();
    }
}

public interface Evaluator
{
    public string Symbol { get; }
    public double Evaluate(Stack<double> numbers);
}

internal class NegativeEvaluator : Evaluator
{
    public string Symbol => "~";
    public double Evaluate(Stack<double> numbers) => numbers.Pop() * -1;
}