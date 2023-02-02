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

    static readonly Regex WhiteRegex = new("^\\s+");
    static readonly Regex NumberRegex = new("^[0-9]+");
    void TokenizeExpression(string expression)
    {
        Match matcher = WhiteRegex.Match(expression[position..]);
        if (matcher.Success)
        {
            position += matcher.Length;
            return;
        }
        
        switch (expression[position])
        {
            case '+':
                tokens.Add(new Token
                {
                    Type = TokenType.Operator,
                    Text = expression.Substring(position, 1)
                });
                position++;
                return;
        }
        
        matcher = NumberRegex.Match(expression[position..]);
        if (matcher.Success)
        {
            tokens.Add(new Token
            {
                Type = TokenType.Number,
                Text = expression.Substring(position, matcher.Length)
            });
            position += matcher.Length;
        }
    }
}