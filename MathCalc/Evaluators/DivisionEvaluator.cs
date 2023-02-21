namespace Frognar.MathCalc.Evaluators;

internal class DivisionEvaluator : Evaluator
{
    public string Symbol => "/";
    public double Evaluate(Stack<double> numbers)
    {
        double divisor = numbers.Pop();
        return numbers.Pop() / divisor;
    }
}