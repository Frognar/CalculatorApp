namespace Frognar.MathCalc.Evaluators;

public static class EvaluateProvider
{
    public static Evaluator GetEvaluator(string symbol)
    {
        if (symbol == "~")
            return new NegativeEvaluator();
        return new AdditionEvaluator();
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

internal class AdditionEvaluator : Evaluator
{
    public string Symbol => "+";
    public double Evaluate(Stack<double> numbers) => numbers.Pop() + numbers.Pop();
}