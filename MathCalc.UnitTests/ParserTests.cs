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
}