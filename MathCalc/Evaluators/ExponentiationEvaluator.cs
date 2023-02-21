namespace Frognar.MathCalc.Evaluators;

internal class ExponentiationEvaluator : Evaluator
{
    public string Symbol => "^";
    public double Evaluate(Stack<double> numbers)
    {
        double exponent = numbers.Pop();
        return Math.Pow(numbers.Pop(), exponent);
    }
}