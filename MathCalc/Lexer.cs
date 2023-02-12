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
        FindWhiteSpaces(expression);

        if (position < expression.Length)
            FindSingleCharacterToken(expression);

        FindNumber(expression[position..]);
        FindName(expression[position..]);
    }

    void FindWhiteSpaces(string line)
    {
        Match wsMatch = Regex.Match(line, "^\\s+");
        if (wsMatch.Success)
            position += wsMatch.Length;
    }

    void FindSingleCharacterToken(string line)
    {
        switch (line[position])
        {
            case '{':
                tokenCollector.OpenBrace(0, position);
                position++;
                break;
            case '}':
                tokenCollector.ClosedBrace(0, position);
                position++;
                break;
            case '(':
                tokenCollector.OpenParen(0, position);
                position++;
                break;
            case ')':
                tokenCollector.ClosedParen(0, position);
                position++;
                break;
            case '<':
                tokenCollector.OpenAngle(0, position);
                position++;
                break;
            case '>':
                tokenCollector.ClosedAngle(0, position);
                position++;
                break;
            case '-':
                tokenCollector.MinusSign(0, position);
                position++;
                break;
            case '+':
                tokenCollector.PlusSign(0, position);
                position++;
                break;
            case '^':
                tokenCollector.ExponentSymbol(0, position);
                position++;
                break;
            case '*':
                tokenCollector.Asterisk(0, position);
                position++;
                break;
            case '/':
                tokenCollector.Slash(0, position);
                position++;
                break;
            case ',':
                tokenCollector.Comma(0, position);
                position++;
                break;
            case '%':
                tokenCollector.PercentSing(0, position);
                position++;
                break;
        }
    }
    
    void FindNumber(string line)
    {
        Match match = Regex.Match(line, "^[0-9]+\\.?[0-9]*");
        if (match.Success)
        {
            tokenCollector.Number(match.Value, 0, position);
            position += match.Length;
        }
    }

    void FindName(string line)
    {
        Match match = Regex.Match(line, "^\\w+");
        if (match.Success)
        {
            tokenCollector.Name(match.Value, 0, position);
            position += match.Length;
        }
    }
}