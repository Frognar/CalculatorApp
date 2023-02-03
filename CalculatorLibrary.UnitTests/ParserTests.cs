namespace CalculatorLibrary.UnitTests;

public class ParserTests
{
    [Fact]
    public void CanCreateParser()
    {
        Parser parser = new();
    }

    [Fact]
    public void ParserCanParseTokens()
    {
        Parser parser = new();

        decimal _ = parser.Parse(Enumerable.Empty<Token>());
    }

    [Fact]
    public void Parse_EmptyCollection_ReturnZero()
    {
        Parser parser = new();

        decimal result = parser.Parse(Enumerable.Empty<Token>());

        Assert.Equal(0M, result);
    }
}