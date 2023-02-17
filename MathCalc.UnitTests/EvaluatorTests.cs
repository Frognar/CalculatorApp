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
}