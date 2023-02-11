using Frognar.MathCalc;

namespace MathCalc.UnitTests;

public class LexerTests : TokenCollector
{
    string tokens;
    readonly Lexer lexer;

    protected LexerTests()
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
    
    void TokenCollector.OpenParen(int line, int position)
    {
        tokens += "OP";
    }
    
    void TokenCollector.ClosedParen(int line, int position)
    {
        tokens += "CP";
    }

    void AssertLexResult(string input, string expected)
    {
        lexer.Lex(input);
        Assert.Equal(expected, tokens);
    }

    public class SingleTokenTests : LexerTests
    {
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

        [Fact]
        public void Lex_OpenParen()
        {
            AssertLexResult("(", "OP");
        }

        [Fact]
        public void Lex_ClosedParen()
        {
            AssertLexResult(")", "CP");
        }
    }
}