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
}