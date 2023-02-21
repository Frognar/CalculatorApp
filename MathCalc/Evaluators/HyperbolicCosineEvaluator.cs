namespace Frognar.MathCalc.Evaluators;

internal  class HyperbolicCosineEvaluator : Evaluator
{
    public string Symbol => "COSH";
    public double Evaluate(Stack<double> numbers) => Math.Cosh(numbers.Pop());
}