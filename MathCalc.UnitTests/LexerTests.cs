using Frognar.MathCalc;

namespace MathCalc.UnitTests;

public class LexerTests : TokenCollector
{
    [Fact]
    public void CanCreateLexer()
    {
        Lexer lexer = new(this);
    }
}