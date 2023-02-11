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
            case ")":
                tokenCollector.ClosedParen(0, 0);
                break;
            case "<":
                tokenCollector.OpenAngle(0, 0);
                break;
            case ">":
                tokenCollector.ClosedAngle(0, 0);
                break;
            case "-":
                tokenCollector.MinusSign(0, 0);
                break;
            case "+":
                tokenCollector.PlusSign(0, 0);
                break;
        }
    }
}