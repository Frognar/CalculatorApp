using Frognar.MathCalc;

namespace MathCalc.UnitTests;

public class LexerTests : TokenCollector
{
    string tokens;
    readonly Lexer lexer;

    public LexerTests()
    {
        tokens = "";
        lexer = new Lexer(this);
    }
    
    void TokenCollector.OpenBrace(int line, int position)
    {
        tokens += "OB";
    }
    
    void TokenCollector.ClosedBrace(int line, int position)
    {
        tokens += "CB";
    }

    [Fact]
    public void Lex_OpenBrace()
    {
        lexer.Lex("{");
        
        Assert.Equal("OB", tokens);
    }

    [Fact]
    public void Lex_ClosedBrace()
    {
        lexer.Lex("}");
        
        Assert.Equal("CB", tokens);
    }
}