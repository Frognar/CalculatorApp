namespace CalculatorLibrary.UnitTests;

public class TokenizerTests
{
    [Fact]
    public void Tokenize_Empty_ReturnsListContainingOnlyStopToken()
    {
        Tokenizer tokenizer = new();
        
        List<Token> tokens = tokenizer.Tokenize("").ToList();
        
        Assert.NotNull(tokens);
        Token token = Assert.Single(tokens);
        Assert.Equal(TokenType.Stop, token.Type);
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

    [Fact]
    public void Tokenize_NumberWithMoreThanOneDigit_ReturnedNumberTokenContainsThatNumber()
    {
        Tokenizer tokenizer = new();

        List<Token> tokens = tokenizer.Tokenize("234").ToList();
        
        Assert.Equal("234", tokens[0].Text);
    }

    [Fact]
    public void Tokenize_NumberFollowedBySpace_ReturnedNumberTokenContainsThatNumberWithoutSpace()
    {
        Tokenizer tokenizer = new();

        List<Token> tokens = tokenizer.Tokenize("234 ").ToList();
        
        Assert.Equal("234", tokens[0].Text);
    }

    [Fact]
    public void Tokenize_NumberFollowedBySpaceAndAnotherNumber_ReturnsTwoNumberTokensFollowedByStopToken()
    {
        Tokenizer tokenizer = new();

        List<Token> tokens = tokenizer.Tokenize("2 34").ToList();
        
        Assert.NotNull(tokens);
        Assert.Equal(3, tokens.Count);
        Assert.Equal(TokenType.Number, tokens[0].Type);
        Assert.Equal(TokenType.Number, tokens[1].Type);
        Assert.Equal(TokenType.Stop, tokens[2].Type);
    }

    [Fact]
    public void Tokenize_NumberFollowedBySpaceAndAnotherNumber_ReturnedNumbersTokenAreInSameOrderAsNumbersInExpression()
    {
        Tokenizer tokenizer = new();

        List<Token> tokens = tokenizer.Tokenize("2 34").ToList();
        
        Assert.Equal("2", tokens[0].Text);
        Assert.Equal("34", tokens[1].Text);
    }

    [Fact]
    public void Tokenize_Operator_ReturnsOperatorTokenFollowedByStopToken()
    {
        Tokenizer tokenizer = new();

        List<Token> tokens = tokenizer.Tokenize("+").ToList();
        
        Assert.NotNull(tokens);
        Assert.Equal(2, tokens.Count);
        Assert.Equal(TokenType.Operator, tokens[0].Type);
        Assert.Equal(TokenType.Stop, tokens[1].Type);
    }
}