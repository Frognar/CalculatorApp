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

    [Fact]
    public void Tokenize_SingleDigit_ReturnsNumberTokenFollowedByStopTokens()
    {
        Tokenizer tokenizer = new();

        List<Token> tokens = tokenizer.Tokenize("2").ToList();
        
        Assert.NotNull(tokens);
        Assert.Equal(2, tokens.Count);
        Assert.Equal(TokenType.Number, tokens[0].Type);
        Assert.Equal(TokenType.Stop, tokens[1].Type);
    }

    [Fact]
    public void Tokenize_SingleDigit_ReturnedNumberTokenContainsThatDigit()
    {
        Tokenizer tokenizer = new();

        List<Token> tokens = tokenizer.Tokenize("2").ToList();
        
        Assert.Equal("2", tokens[0].Text);
    }
}