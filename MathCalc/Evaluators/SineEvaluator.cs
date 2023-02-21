namespace Frognar.MathCalc.Evaluators;

internal class SineEvaluator : Evaluator
{
    public string Symbol => "SIN";
    public double Evaluate(Stack<double> numbers) => Math.Sin(numbers.Pop());
}