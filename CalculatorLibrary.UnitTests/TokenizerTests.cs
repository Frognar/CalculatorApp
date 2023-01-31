namespace CalculatorLibrary.UnitTests;

public class TokenizerTests
{
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