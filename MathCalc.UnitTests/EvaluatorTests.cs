using System.Data;
using Frognar.MathCalc;
using Frognar.MathCalc.Expressions;

namespace MathCalc.UnitTests;

public class EvaluatorTests
{
    [Fact]
    public void CanCreateEvaluator()
    {
        Evaluator _ = new(new Expression());
    }

    [Fact]
    public void Evaluate_ExpressionWithErrors_ThrowInvalidExpressionException()
    {
        Expression expression = new();
        expression.AddError("ERROR");
        Evaluator evaluator = new(expression);

        Assert.Throws<InvalidExpressionException>(() => evaluator.Evaluate());
    }
}