using Frognar.MathCalc;

namespace MathCalc.UnitTests;

public class CalculatorTests
{
    [Fact]
    public void CreateCalculator()
    {
        Calculator _ = new();
    }
    
    [Fact]
    public void CreateCalculatorWithExpression()
    {
        Calculator _ = new("-10 + ( 3 * 2 ) ^ 2 ^ 3 - 25 / 5");
    }

    [Fact]
    public void Evaluate_EvaluatesExpression()
    {
        Calculator calculator = new();
        
        Assert.Equal(1679601d, calculator.Evaluate("-10 + ( 3 * 2 ) ^ 2 ^ 3 - 25 / 5"), 0.001);
    }

    [Fact]
    public void Evaluate_ExpressionFromConstructor_EvaluatesExpression()
    {
        Calculator calculator = new("-10 + ( 3 * 2 ) ^ 2 ^ 3 - 25 / 5");
        
        Assert.Equal(1679601d, calculator.Evaluate(), 0.001);
    }
}