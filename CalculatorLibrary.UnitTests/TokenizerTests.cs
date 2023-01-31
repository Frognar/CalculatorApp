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

    [Fact]
    public void Tokenize_ReturnListOfTokens()
    {
        Tokenizer tokenizer = new();
        IEnumerable<Token> tokens = tokenizer.Tokenize("");
    }

    [Fact]
    public void Tokenize_Empty_ReturnsListContainingOnlyStopToken()
    {
        Tokenizer tokenizer = new();
        
        List<Token> tokens = tokenizer.Tokenize("").ToList();
        
        Assert.NotNull(tokens);
        Assert.Single(tokens);
        Assert.Equal(TokenType.Stop, tokens.First().Type);
    }
}