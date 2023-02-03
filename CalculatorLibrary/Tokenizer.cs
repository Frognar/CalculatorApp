using System.Text.RegularExpressions;

namespace CalculatorLibrary;

public class Tokenizer
{
    readonly List<Token> tokens = new();
    int position;
    
    public IEnumerable<Token> Tokenize(string expression)
    {
        tokens.Clear();
        for (position = 0; position < expression.Length;)
            TokenizeExpression(expression);

        tokens.Add(Token.Stop);
        return tokens;
    }

    void TokenizeExpression(string expression)
    {
        if (FindWhiteSpace(expression) == false &&
            FindSingleCharacterToken(expression) == false &&
            FindNumber(expression) == false)
        {
            position++;
            // Unknown
        }
    }

    static readonly Regex WhiteRegex = new("^\\s+");
    bool FindWhiteSpace(string expression)
    {
        Match matcher = WhiteRegex.Match(expression[position..]);
        if (!matcher.Success)
            return false;
        
        position += matcher.Length;
        return true;
    }

    bool FindSingleCharacterToken(string expression)
    {
        switch (expression[position])
        {
            case '+':
            case '-':
            case '*':
            case '/':
            case '^':
                tokens.Add(new Token
                {
                    Type = TokenType.Operator,
                    Text = expression.Substring(position, 1)
                });
                break;
            default:
                return false;
        }

        position++;
        return true;
    }
    
    static readonly Regex NumberRegex = new("^(\\.[0-9]+|[0-9]+\\.[0-9]*|[0-9]+)");
    bool FindNumber(string expression)
    {
        Match matcher = NumberRegex.Match(expression[position..]);
        if (!matcher.Success)
            return false;
       
        tokens.Add(new Token
        {
            Type = TokenType.Number,
            Text = expression.Substring(position, matcher.Length)
        });
        
        position += matcher.Length;
        return true;
    }
}