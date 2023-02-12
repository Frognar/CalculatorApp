using System.Text.RegularExpressions;

namespace Frognar.MathCalc;

public class Lexer
{
    readonly TokenCollector tokenCollector;
    int position;

    public Lexer(TokenCollector tokenCollector)
    {
        this.tokenCollector = tokenCollector;
    }

    public void Lex(string expression)
    {
        position = 0;
        Match wsMatch = Regex.Match(expression, "^\\s+");
        if (wsMatch.Success)
            expression = expression[wsMatch.Length..];
        
        switch (expression)
        {
            case "{":
                tokenCollector.OpenBrace(0, position);
                break;
            case "}":
                tokenCollector.ClosedBrace(0, position);
                break;
            case "(":
                tokenCollector.OpenParen(0, position);
                break;
            case ")":
                tokenCollector.ClosedParen(0, position);
                break;
            case "<":
                tokenCollector.OpenAngle(0, position);
                break;
            case ">":
                tokenCollector.ClosedAngle(0, position);
                break;
            case "-":
                tokenCollector.MinusSign(0, position);
                break;
            case "+":
                tokenCollector.PlusSign(0, position);
                break;
            case "^":
                tokenCollector.ExponentSymbol(0, position);
                break;
            case "*":
                tokenCollector.Asterisk(0, position);
                break;
            case "/":
                tokenCollector.Slash(0, position);
                break;
            case ",":
                tokenCollector.Comma(0, position);
                break;
            case "%":
                tokenCollector.PercentSing(0, position);
                break;
        }

        Match match = Regex.Match(expression, "^\\w+");
        if (match.Success)
        {
            tokenCollector.Name(match.Value, 0, position);
        }
    }
}