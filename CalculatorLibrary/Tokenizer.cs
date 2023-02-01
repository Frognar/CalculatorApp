namespace CalculatorLibrary;

public class Tokenizer
{
    public IEnumerable<Token> Tokenize(string expression)
    {
        List<Token> tokens = new();
        if (expression.Any())
        {
            tokens.Add(new Token
            {
                Type = TokenType.Number,
                Text = "",
            });
        }
        
        tokens.Add(Token.Stop);
        return tokens;
    }
}