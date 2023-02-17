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

        string[] expr = expression.ToString().Split(' ');
        if (expr.Length == 1)
            return double.Parse(expr[0]);
        
        return double.Parse(expr[0]) + double.Parse(expr[1]);
    }
}