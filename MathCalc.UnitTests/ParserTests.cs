using Frognar.MathCalc;
using Frognar.MathCalc.Enums;
using Frognar.MathCalc.Expressions;

namespace MathCalc.UnitTests;

public class ParserTests
{
    readonly Lexer lexer;
    readonly ExpressionBuilder builder;
    readonly Parser parser;

    public ParserTests()
    {
        builder = new ExpressionBuilder();
        parser = new Parser(builder);
        lexer = new Lexer(parser);
    }

    [Fact]
    public void Parse_SingleNumber()
    {
        lexer.Lex("123");
        parser.HandleEvent(ParserEvent.EOF, -1, -1);

        Expression expression = builder.GetExpression();
        Assert.Equal(123d, expression.Evaluate(), 0.01);
    }

    [Fact]
    public void Parse_SingleNegativeNumber()
    {
        lexer.Lex("-123");
        parser.HandleEvent(ParserEvent.EOF, -1, -1);

        Expression expression = builder.GetExpression();
        Assert.Equal(-123d, expression.Evaluate(), 0.01);
    }
}