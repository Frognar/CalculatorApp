namespace CalculatorLibrary;

public class Tokenizer
{
    public IEnumerable<Token> Tokenize(string expression)
    {
        Token stop = new()
        {
            Type = TokenType.Stop,
            Text = "",
        };

        return new[] { stop };
    }
}