using Frognar.MathCalc;

namespace MathCalc.UnitTests;

public class LexerTests : TokenCollector
{
    string tokens = "";
    
    void TokenCollector.OpenBrace(int line, int position)
    {
        tokens += "OB";
    }
    
    [Fact]
    public void CanCreateLexer()
    {
        Lexer lexer = new(this);
    }

    [Fact]
    public void Lex_OpenBrace()
    {
        Lexer lexer = new(this);

        lexer.Lex("{");
        
        Assert.Equal("OB", tokens);
    }
}