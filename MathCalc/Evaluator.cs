using System.Data;
using Frognar.MathCalc.Expressions;

namespace Frognar.MathCalc;

public class Evaluator
{
    public Evaluator(Expression expression)
    {
    }

    public double Evaluate()
    {
        throw new InvalidExpressionException();
    }
}