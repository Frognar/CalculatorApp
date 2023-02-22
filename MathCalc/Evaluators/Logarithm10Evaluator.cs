namespace Frognar.MathCalc.Evaluators;

internal class Logarithm10Evaluator : Evaluator
{
    public string Symbol => "LOG10";
    public double Evaluate(Stack<double> numbers) => Math.Log10(numbers.Pop());
}