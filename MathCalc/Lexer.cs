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
        switch (expression)
        {
            case "{":
                tokenCollector.OpenBrace(0, 0);
                break;
            case "}":
                tokenCollector.ClosedBrace(0, 0);
                break;
            case "(":
                tokenCollector.OpenParen(0, 0);
                break;
        }
    }
}