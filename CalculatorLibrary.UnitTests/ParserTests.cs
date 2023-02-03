namespace CalculatorLibrary.UnitTests;

public class ParserTests
{
    [Fact]
    public void Parse_EmptyCollection_ReturnZero()
    {
        Parser parser = new();

        decimal result = parser.Parse(Enumerable.Empty<Token>());

        Assert.Equal(0M, result);
    }

    [Fact]
    public void Parse_StopToken_ReturnsZero()
    {
        Parser parser = new();

        decimal result = parser.Parse(new[] { Token.Stop });

        Assert.Equal(0M, result);
    }

    [Fact]
    public void Parse_NumberToken_ReturnsThatNumber()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[] { new Token { Type = TokenType.Number, Text = "124.5" }, Token.Stop });
        
        Assert.Equal(124.5M, result);
    }

    [Fact]
    public void Parse_NotEmptyCollectionWithoutStopToken_ThrowsException()
    {
        Parser parser = new();

        Assert.Throws<Exception>(
            () => parser.Parse(new[] { new Token { Type = TokenType.Number, Text = "1" } }));
    }
}