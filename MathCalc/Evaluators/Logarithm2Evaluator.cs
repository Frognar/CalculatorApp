namespace Frognar.MathCalc.Evaluators;

internal class Logarithm2Evaluator : Evaluator
{
    public string Symbol => "LOG2";
    public double Evaluate(Stack<double> numbers) => Math.Log2(numbers.Pop());
}