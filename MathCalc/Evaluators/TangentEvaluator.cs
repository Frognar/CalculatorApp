namespace Frognar.MathCalc.Evaluators;

internal class TangentEvaluator : Evaluator
{
    public string Symbol => "TAN";
    public double Evaluate(Stack<double> numbers) => Math.Tan(numbers.Pop());
}