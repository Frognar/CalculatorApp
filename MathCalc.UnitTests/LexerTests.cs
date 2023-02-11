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

    void AssertLexResult(string input, string expected)
    {
        lexer.Lex(input);
        Assert.Equal(expected, tokens);
    }

    [Fact]
    public void Lex_OpenBrace()
    {
        AssertLexResult("{", "OB");
    }

    [Fact]
    public void Lex_ClosedBrace()
    {
        AssertLexResult("}", "CB");
    }
}