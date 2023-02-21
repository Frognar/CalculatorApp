namespace Frognar.MathCalc.Evaluators;

internal class AbsoluteValueEvaluator : Evaluator
{
    public string Symbol => "ABS";
    public double Evaluate(Stack<double> numbers) => Math.Abs(numbers.Pop());
}