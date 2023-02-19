using System.Data;
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
    public void Evaluate_ExpressionFromConstructor()
    {
        Calculator calculator = new("-10 + ( 3 * 2 ) ^ 2 ^ 3 - 25 / 5");
        
        Assert.Equal(1679601d, calculator.Evaluate(), 0.001);
    }

    [Fact]
    public void Evaluate_MultipleExpressions()
    {
        Calculator calculator = new("-10 + ( 3 * 2 ) ^ 2 ^ 3 - 25 / 5");
        
        Assert.Equal(1679601d, calculator.Evaluate(), 0.001);
        Assert.Equal(123d, calculator.Evaluate("99 + 25 - 1 * 5 ^ 0"));
    }

    [Fact]
    public void Evaluate_InvalidExpression()
    {
        Calculator calculator = new("123 ++ 3");
        Exception ex = Assert.Throws<InvalidExpressionException>(() => calculator.Evaluate());
        Assert.Equal("Syntax error: Expr. Operator|Plus. line 1, position 6.", ex.Message);
    }
}