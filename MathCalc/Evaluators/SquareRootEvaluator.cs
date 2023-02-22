namespace Frognar.MathCalc.Evaluators;

internal class SquareRootEvaluator : Evaluator
{
    public string Symbol => "SQRT";
    public double Evaluate(Stack<double> numbers) => Math.Sqrt(numbers.Pop());
}