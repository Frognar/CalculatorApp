namespace Frognar.MathCalc.Evaluators;

internal class CubeRootEvaluator : Evaluator
{
    public string Symbol => "CBRT";
    public double Evaluate(Stack<double> numbers) => Math.Cbrt(numbers.Pop());
}