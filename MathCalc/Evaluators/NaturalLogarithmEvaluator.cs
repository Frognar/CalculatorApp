namespace Frognar.MathCalc.Evaluators;

internal class NaturalLogarithmEvaluator : Evaluator
{
    public string Symbol => "LN";
    public double Evaluate(Stack<double> numbers) => Math.Log(numbers.Pop());
}