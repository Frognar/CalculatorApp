using System.Text.RegularExpressions;

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
        Match wsMatch = Regex.Match(expression, "^\\s+");
        if (wsMatch.Success)
            expression = expression[wsMatch.Length..];
        
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
            case "^":
                tokenCollector.ExponentSymbol(0, 0);
                break;
            case "*":
                tokenCollector.Asterisk(0, 0);
                break;
            case "/":
                tokenCollector.Slash(0, 0);
                break;
            case ",":
                tokenCollector.Comma(0, 0);
                break;
            case "%":
                tokenCollector.PercentSing(0, 0);
                break;
        }

        Match match = Regex.Match(expression, "^\\w+");
        if (match.Success)
        {
            tokenCollector.Name(match.Value, 0, 0);
        }
    }
}