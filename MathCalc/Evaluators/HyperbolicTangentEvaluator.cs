namespace Frognar.MathCalc.Evaluators;

internal class HyperbolicTangentEvaluator : Evaluator
{
    public string Symbol => "TANH";
    public double Evaluate(Stack<double> numbers) => Math.Tanh(numbers.Pop());
}