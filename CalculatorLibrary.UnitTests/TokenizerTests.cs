namespace CalculatorLibrary.UnitTests;

public class TokenizerTests
{
    [Fact]
    public void Tokenizer_CanBeCreated()
    {
        Tokenizer tokenizer = new();
    }

    [Fact]
    public void Token_CanBeCreated()
    {
        Token token = new()
        {
            Type = TokenType.Stop,
            Text = "",
        };
    }
}