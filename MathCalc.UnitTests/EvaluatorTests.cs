using System.Data;
using Frognar.MathCalc;
using Frognar.MathCalc.Enums;
using Frognar.MathCalc.Expressions;

namespace MathCalc.UnitTests;

public class EvaluatorTests
{
    Lexer lexer;
    Parser parser;
    Builder builder;

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
        Assert.Equal(expected, evaluator.Evaluate(), 0.0001);
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
}