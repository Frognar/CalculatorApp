namespace Frognar.MathCalc.Evaluators;

internal class NegativeEvaluator : Evaluator
{
    public string Symbol => "~";
    public double Evaluate(Stack<double> numbers) => numbers.Pop() * -1;
}