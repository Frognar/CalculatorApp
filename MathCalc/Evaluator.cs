using System.Data;
using Frognar.MathCalc.Expressions;

namespace Frognar.MathCalc;

public class Evaluator
{
    readonly Expression expression;

    public Evaluator(Expression expression)
    {
        this.expression = expression;
    }

    public double Evaluate()
    {
        if (string.IsNullOrEmpty(expression.GetError()) == false)
            throw new InvalidExpressionException();

        return double.Parse(expression.ToString());
    }
}