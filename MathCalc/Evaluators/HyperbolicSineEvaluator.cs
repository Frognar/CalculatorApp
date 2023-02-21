namespace Frognar.MathCalc.Evaluators;

internal class HyperbolicSineEvaluator : Evaluator
{
    public string Symbol => "SINH";
    public double Evaluate(Stack<double> numbers) => Math.Sinh(numbers.Pop());
}