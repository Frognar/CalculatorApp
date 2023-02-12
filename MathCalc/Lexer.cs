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
        for (position = 0; position < expression.Length;)
            LexLine(expression);
    }

    void LexLine(string line)
    {
        if (FindToken(line) == false)
            tokenCollector.Error(1, ++position);
    }

    bool FindToken(string line)
    {
        return FindWhiteSpaces(line)
               || FindSingleCharacterToken(line)
               || FindNumber(line)
               || FindName(line);
    }

    bool FindWhiteSpaces(string line)
    {
        Match wsMatch = Regex.Match(line[position..], "^\\s+");
        if (wsMatch.Success == false)
            return false;
        
        position += wsMatch.Length;
        return true;
    }

    bool FindSingleCharacterToken(string line)
    {
        switch (line[position])
        {
            case '{':
                tokenCollector.OpenBrace(0, position);
                break;
            case '}':
                tokenCollector.ClosedBrace(0, position);
                break;
            case '(':
                tokenCollector.OpenParen(0, position);
                break;
            case ')':
                tokenCollector.ClosedParen(0, position);
                break;
            case '<':
                tokenCollector.OpenAngle(0, position);
                break;
            case '>':
                tokenCollector.ClosedAngle(0, position);
                break;
            case '-':
                tokenCollector.MinusSign(0, position);
                break;
            case '+':
                tokenCollector.PlusSign(0, position);
                break;
            case '^':
                tokenCollector.ExponentSymbol(0, position);
                break;
            case '*':
                tokenCollector.Asterisk(0, position);
                break;
            case '/':
                tokenCollector.Slash(0, position);
                break;
            case ',':
                tokenCollector.Comma(0, position);
                break;
            case '%':
                tokenCollector.PercentSing(0, position);
                break;
            default:
                return false;
        }

        position++;
        return true;
    }
    
    bool FindNumber(string line)
    {
        Match match = Regex.Match(line[position..], "^[0-9]+\\.?[0-9]*");
        if (match.Success == false)
            return false;

        tokenCollector.Number(match.Value, 0, position);
        position += match.Length;
        return true;
    }

    bool FindName(string line)
    {
        Match match = Regex.Match(line[position..], "^\\w+");
        if (match.Success == false)
            return false;
        
        tokenCollector.Name(match.Value, 0, position);
        position += match.Length;
        return true;
    }
}