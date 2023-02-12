using Frognar.MathCalc;

namespace MathCalc.UnitTests;

public class LexerTests : TokenCollector
{
    string tokens;
    bool firstToken = true;
    readonly Lexer lexer;

    protected LexerTests()
    {
        tokens = "";
        lexer = new Lexer(this);
    }

    void AddToken(string token)
    {
        if (firstToken == false)
            tokens += ",";

        firstToken = false;
        tokens += token;
    }
    
    void TokenCollector.OpenBrace(int line, int position)
    {
        AddToken("OB");
    }
    
    void TokenCollector.ClosedBrace(int line, int position)
    {
        AddToken("CB");
    }
    
    void TokenCollector.OpenParen(int line, int position)
    {
        AddToken("OP");
    }
    
    void TokenCollector.ClosedParen(int line, int position)
    {
        AddToken("CP");
    }

    void TokenCollector.OpenAngle(int line, int position)
    {
        AddToken("OA");
    }

    void TokenCollector.ClosedAngle(int line, int position)
    {
        AddToken("CA");
    }

    void TokenCollector.MinusSign(int line, int position)
    {
        AddToken("MS");
    }

    void TokenCollector.PlusSign(int line, int position)
    {
        AddToken("PS");
    }

    void TokenCollector.ExponentSymbol(int line, int position)
    {
        AddToken("ES");
    }

    void TokenCollector.Asterisk(int line, int position)
    {
        AddToken("A");
    }

    void TokenCollector.Slash(int line, int position)
    {
        AddToken("S");
    }

    void TokenCollector.Comma(int line, int position)
    {
        AddToken("C");
    }

    void TokenCollector.PercentSing(int line, int position)
    {
        AddToken("P");
    }

    void TokenCollector.Name(string name, int line, int position)
    {
        AddToken($"#{name}#");
    }

    void TokenCollector.Number(string number, int line, int position)
    {
        AddToken($"|{number}|");
    }

    void Reset()
    {
        firstToken = true;
        tokens = "";
    }
    
    void AssertLexResult(string input, string expected)
    {
        Reset();
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

        [Fact]
        public void Lex_Percentage()
        {
            AssertLexResult("%", "P");
        }

        [Fact]
        public void Lex_Name()
        {
            AssertLexResult("name", "#name#");
        }

        [Fact]
        public void Lex_ComplexName()
        {
            AssertLexResult("NaMe_123", "#NaMe_123#");
        }

        [Fact]
        public void Lex_WhiteSpaces()
        {
            AssertLexResult(" \t\n  ", "");
        }

        [Fact]
        public void Lex_WhiteSpacesBeforeToken()
        {
            AssertLexResult(" \t\n (", "OP");
        }

        [Fact]
        public void Lex_Number()
        {
            AssertLexResult("12345.6789", "|12345.6789|");
            AssertLexResult(" 12345.6789", "|12345.6789|");
        }
    }

    public class MultipleTokenTests : LexerTests
    {
        [Fact]
        public void Lex_SimpleSequence()
        {
            AssertLexResult("{}", "OB,CB");
        }
    } 
}