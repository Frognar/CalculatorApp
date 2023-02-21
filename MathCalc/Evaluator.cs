using System.Data;
using System.Globalization;
using Frognar.MathCalc.Evaluators;
using Frognar.MathCalc.Expressions;

namespace Frognar.MathCalc;

internal class Evaluator
{
    readonly Expression expression;

    public Evaluator(Expression expression)
    {
        this.expression = expression;
    }

    public double Evaluate()
    {
        string error = expression.GetError();
        if (string.IsNullOrEmpty(error) == false)
            throw new InvalidExpressionException(error);

        return EvaluateExpression();
    }

    double EvaluateExpression()
    {
        Stack<double> numbers = new();
        string[] expr = expression.ToString().Split(' ');
        foreach (string symbol in expr)
        {
            numbers.Push(double.TryParse(symbol, CultureInfo.InvariantCulture, out double number)
                ? number
                : EvaluatorProvider.GetEvaluator(symbol).Evaluate(numbers));
        }
 
        return numbers.Pop();
    }
}