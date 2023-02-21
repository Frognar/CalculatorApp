namespace Frognar.MathCalc.Evaluators;

public interface Evaluator
{
    public string Symbol { get; }
    public double Evaluate(Stack<double> numbers);
}