namespace Frognar.MathCalc.Evaluators;

internal class CosineEvaluator : Evaluator
{
    public string Symbol => "COS";
    public double Evaluate(Stack<double> numbers) => Math.Cos(numbers.Pop());
}