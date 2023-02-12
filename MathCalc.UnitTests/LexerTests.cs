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

    void TokenCollector.OpenAngle(int line, int position)
    {
        tokens += "OA";
    }

    void TokenCollector.ClosedAngle(int line, int position)
    {
        tokens += "CA";
    }

    void TokenCollector.MinusSign(int line, int position)
    {
        tokens += "MS";
    }

    void TokenCollector.PlusSign(int line, int position)
    {
        tokens += "PS";
    }

    void TokenCollector.ExponentSymbol(int line, int position)
    {
        tokens += "ES";
    }

    void TokenCollector.Asterisk(int line, int position)
    {
        tokens += "A";
    }

    void TokenCollector.Slash(int line, int position)
    {
        tokens += "S";
    }

    void TokenCollector.Comma(int line, int position)
    {
        tokens += "C";
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

        [Fact]
        public void Lex_OpenAngle()
        {
            AssertLexResult("<", "OA");
        }

        [Fact]
        public void Lex_ClosedAngle()
        {
            AssertLexResult(">", "CA");
        }

        [Fact]
        public void Lex_MinusSign()
        {
            AssertLexResult("-", "MS");
        }

        [Fact]
        public void Lex_PlusSign()
        {
            AssertLexResult("+", "PS");
        }

        [Fact]
        public void Lex_ExponentSymbol()
        {
            AssertLexResult("^", "ES");
        }

        [Fact]
        public void Lex_Asterisk()
        {
            AssertLexResult("*", "A");
        }

        [Fact]
        public void Lex_Slash()
        {
            AssertLexResult("/", "S");
        }

        [Fact]
        public void Lex_Comma()
        {
            AssertLexResult(",", "C");
        }
    }
}