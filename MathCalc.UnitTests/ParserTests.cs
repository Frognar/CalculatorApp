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
    public void Parse_SingleNumber()
    {
        lexer.Lex("123");
        
        Assert.Equal("123", builder.GetExpression());
    }

    [Fact]
    public void Parse_SingleNegativeNumber()
    {
        lexer.Lex("-123");
        
        Assert.Equal("123 ~", builder.GetExpression());
    }

    [Fact]
    public void Parse_SubExpression()
    {
        lexer.Lex("123 - 23");
        
        Assert.Equal("123 23 -", builder.GetExpression());
    }

    [Fact]
    public void Parse_AddExpression()
    {
        lexer.Lex("100 + 23");
        
        Assert.Equal("100 23 +", builder.GetExpression());
    }
}