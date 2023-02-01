namespace CalculatorLibrary;

public class Tokenizer
{
    public IEnumerable<Token> Tokenize(string expression)
    {
        List<Token> tokens = new();
        foreach (string partOfExpression in expression.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            tokens.Add(new Token
            {
                Type = TokenType.Number,
                Text = partOfExpression
            });
        }
        
        tokens.Add(Token.Stop);
        return tokens;
    }
}