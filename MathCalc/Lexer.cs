using System.Text.RegularExpressions;
using Frognar.MathCalc.Helpers;

namespace Frognar.MathCalc;

internal class Lexer
{
    readonly TokenCollector tokenCollector;
    int position;
    int lineNumber;

    public Lexer(TokenCollector tokenCollector)
    {
        this.tokenCollector = tokenCollector;
    }

    public void Lex(string expression)
    {
        lineNumber = 1;
        foreach (string line in expression.Split('\n'))
        {
            LexLine(line);
            lineNumber++;
        }
    }

    void LexLine(string line)
    {
        for (position = 0; position < line.Length;)
            LexToken(line);
    }

    void LexToken(string line)
    {
        if (FindToken(line) == false)
            tokenCollector.Error(lineNumber, ++position);
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
        Match wsMatch = RegexHelper.WhiteSpacesPattern.Match(line[position..]);
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
                tokenCollector.OpenBrace(lineNumber, position);
                break;
            case '}':
                tokenCollector.ClosedBrace(lineNumber, position);
                break;
            case '(':
                tokenCollector.OpenParen(lineNumber, position);
                break;
            case ')':
                tokenCollector.ClosedParen(lineNumber, position);
                break;
            case '<':
                tokenCollector.OpenAngle(lineNumber, position);
                break;
            case '>':
                tokenCollector.ClosedAngle(lineNumber, position);
                break;
            case '-':
                tokenCollector.MinusSign(lineNumber, position);
                break;
            case '+':
                tokenCollector.PlusSign(lineNumber, position);
                break;
            case '^':
                tokenCollector.ExponentSymbol(lineNumber, position);
                break;
            case '*':
                tokenCollector.Asterisk(lineNumber, position);
                break;
            case '/':
                tokenCollector.Slash(lineNumber, position);
                break;
            case ',':
                tokenCollector.Comma(lineNumber, position);
                break;
            case '%':
                tokenCollector.PercentSign(lineNumber, position);
                break;
            default:
                return false;
        }

        position++;
        return true;
    }

    bool FindNumber(string line)
    {
        Match match = RegexHelper.NumberPattern.Match(line[position..]);
        if (match.Success == false)
            return false;

        tokenCollector.Number(match.Value.Replace(',', '.'), lineNumber, position);
        position += match.Length;
        return true;
    }

    bool FindName(string line)
    {
        Match match = RegexHelper.NamePattern.Match(line[position..]);
        if (match.Success == false)
            return false;

        tokenCollector.Name(match.Value, lineNumber, position);
        position += match.Length;
        return true;
    }
}