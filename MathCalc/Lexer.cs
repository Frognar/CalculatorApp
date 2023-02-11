namespace Frognar.MathCalc;

public class Lexer
{
    readonly TokenCollector tokenCollector;

    public Lexer(TokenCollector tokenCollector)
    {
        this.tokenCollector = tokenCollector;
    }

    public void Lex(string expression)
    {
        tokenCollector.OpenBrace(0, 0);
    }
}