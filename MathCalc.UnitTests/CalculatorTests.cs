using Frognar.MathCalc;

namespace MathCalc.UnitTests;

public class CalculatorTests
{
    [Fact]
    public void CreateCalculator()
    {
        Calculator c = new();
    }

    [Fact]
    public void Evaluate_EvaluatesExpression()
    {
        Calculator calculator = new();
        
        Assert.Equal(1679601d, calculator.Evaluate("-10 + ( 3 * 2 ) ^ 2 ^ 3 - 25 / 5"), 0.001);
    }
}