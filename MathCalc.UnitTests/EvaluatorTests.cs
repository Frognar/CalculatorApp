using System.Data;
using Frognar.MathCalc;
using Frognar.MathCalc.Enums;
using Frognar.MathCalc.Expressions;

namespace MathCalc.UnitTests;

public class EvaluatorTests
{
    readonly Lexer lexer;
    readonly Parser parser;
    readonly Builder builder;

    public EvaluatorTests()
    {
        builder = new ExpressionBuilder();
        parser = new Parser(builder);
        lexer = new Lexer(parser);
    }

    Expression GetExpression(string expression)
    {
        lexer.Lex(expression);
        parser.HandleEvent(ParserEvent.EOF, -1, -1);
        return builder.GetExpression();
    }

    void AssertEvaluation(string expression, double expected)
    {
        Evaluator evaluator = new(GetExpression(expression));
        Assert.Equal(expected, evaluator.Evaluate(), 0.000000000000001);
    }
    
    [Fact]
    public void Evaluate_ExpressionWithErrors_ThrowInvalidExpressionException()
    {
        Evaluator evaluator = new(GetExpression(""));
        InvalidExpressionException ex = Assert.Throws<InvalidExpressionException>(() => evaluator.Evaluate());
        Assert.Equal("Syntax error: Expr. Expr|EOF. line -1, position -1.", ex.Message);
    }

    [Fact]
    public void Evaluate_ExpressionWithSingleNumber()
    {
        AssertEvaluation("123", 123d);
    }

    [Fact]
    public void Evaluate_DecimalNumber()
    {
        AssertEvaluation("2.5", 2.5);
    }

    [Fact]
    public void Evaluate_XPlusY()
    {
        AssertEvaluation("100 + 23", 123d);
    }

    [Fact]
    public void Evaluate_MinusX()
    {
        AssertEvaluation("-123", -123d);
    }

    [Fact]
    public void Evaluate_XMinusY()
    {
        AssertEvaluation("123 - 23", 100d);
    }

    [Fact]
    public void Evaluate_XMinusMinusY()
    {
        AssertEvaluation("100 - -23", 123d);
    }

    [Fact]
    public void Evaluate_XTimesY()
    {
        AssertEvaluation("100 * 2", 200d);
    }

    [Fact]
    public void Evaluate_XDividedByY()
    {
        AssertEvaluation("200 / 2", 100d);
    }

    [Fact]
    public void Evaluate_XToPowerOfY()
    {
        AssertEvaluation("2 ^ 3", 8d);
    }

    [Fact]
    public void Evaluate_ComplexExpression()
    {
        AssertEvaluation("-10 + ( 3 * 2 ) ^ 2 ^ 3 - 25 / 5", 1679601d);
    }

    [Theory]
    [InlineData("SIN(PI/2)", 1)]
    [InlineData("SINH(PI/2)", 2.3012989023072947)]
    [InlineData("COS(π/2)", 0)]
    [InlineData("COSH(π/2)", 2.5091784786580567)]
    [InlineData("TAN(pi/4)", 1)]
    [InlineData("TANH(pi/4)", 0.65579420263267241)]
    [InlineData("ABS(-2/2)", 1)]
    [InlineData("SQRT(8/2)", 2)]
    [InlineData("CBRT(16/2)", 2)]
    [InlineData("LOG2(4/2)", 1)]
    [InlineData("LOG10(4/2)", 0.3010299956639812)]
    [InlineData("LN(4/2)", 0.69314718055994529)]
    public void Evaluate_Functions(string expression, double expectedValue)
    {
        AssertEvaluation(expression, expectedValue);
    }

    [Theory]
    [InlineData("PI", 3.1415926535897931)]
    [InlineData("E", 2.7182818284590451)]
    [InlineData("TAU", 6.2831853071795862)]
    public void Evaluate_MathConstant(string token, double expectedValue)
    {
        AssertEvaluation(token, expectedValue);
    }
}