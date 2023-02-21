namespace Frognar.MathCalc.Evaluators;

internal class MultiplicationEvaluator : Evaluator
{
    public string Symbol => "*";
    public double Evaluate(Stack<double> numbers) => numbers.Pop() * numbers.Pop();
}