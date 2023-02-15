using Frognar.MathCalc;

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
    public void Parse_X()
    {
        lexer.Lex("123");
        
        Assert.Equal("123", builder.GetExpression());
    }

    [Fact]
    public void Parse_MinusX()
    {
        lexer.Lex("-123");
        
        Assert.Equal("123 ~", builder.GetExpression());
    }

    [Fact]
    public void Parse_XMinusY()
    {
        lexer.Lex("123 - 23");
        
        Assert.Equal("123 23 -", builder.GetExpression());
    }

    [Fact]
    public void Parse_XPlusY()
    {
        lexer.Lex("100 + 23");
        
        Assert.Equal("100 23 +", builder.GetExpression());
    }

    [Fact]
    public void Parse_XPlusMuinusY()
    {
        lexer.Lex("100 + -23");
        
        Assert.Equal("100 23 ~ +", builder.GetExpression());
    }

    [Fact]
    public void Parse_XTimesY()
    {
        lexer.Lex("10 * 5");
        
        Assert.Equal("10 5 *", builder.GetExpression());
    }

    [Fact]
    public void Parse_XTimesYPlusZ()
    {
        lexer.Lex("10 * 2 + 5");
        
        Assert.Equal("10 2 * 5 +", builder.GetExpression());
    }

    [Fact]
    public void Parse_XDevidedByY()
    {
        lexer.Lex("10 / 2");
        
        Assert.Equal("10 2 /", builder.GetExpression());
    }

    [Fact]
    public void Parse_XDevidedByMinusY()
    {
        lexer.Lex("10 / -2");
        
        Assert.Equal("10 2 ~ /", builder.GetExpression());
    }

    [Fact]
    public void Parse_XTimesMinusY()
    {
        lexer.Lex("10 * -2");
        
        Assert.Equal("10 2 ~ *", builder.GetExpression());
    }

    [Fact]
    public void Parse_XTimexYPlusMinusZ()
    {
        lexer.Lex("10 * 2 + -5");
        
        Assert.Equal("10 2 * 5 ~ +", builder.GetExpression());
    }

    [Fact]
    public void Parse_XToPowerOfY()
    {
        lexer.Lex("10 ^ 2");
        
        Assert.Equal("10 2 ^", builder.GetExpression());
    }

    [Fact]
    public void Parse_XToPowerOfMinusY()
    {
        lexer.Lex("10 ^ -2");
        
        Assert.Equal("10 2 ~ ^", builder.GetExpression());
    }

    [Fact]
    public void Parse_XTimeYPlusZInParen()
    {
        lexer.Lex("10 * (1 + 1)");
        
        Assert.Equal("10 1 1 + *", builder.GetExpression());
    }

    [Fact]
    public void Parse_ComplexExpression()
    {
        lexer.Lex("10 + ( 3 * 2 ) ^ 2 ^ -3 - 25 / 5");
        
        Assert.Equal("10 3 2 * 2 3 ~ ^ ^ + 25 5 / -", builder.GetExpression());
    }
}