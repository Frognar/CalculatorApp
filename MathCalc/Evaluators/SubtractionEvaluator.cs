namespace Frognar.MathCalc.Evaluators;

internal class SubtractionEvaluator : Evaluator
{
    public string Symbol => "-";
    public double Evaluate(Stack<double> numbers)
    {
        double subtrahend = numbers.Pop();
        return numbers.Pop() - subtrahend;
    }
}