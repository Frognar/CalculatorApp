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

    [Fact]
    public void Parse_TwoNumbersWithPlusOperatorBetween_ReturnSumOfThoseNumbers()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Number, Text = "1" },
                new Token { Type = TokenType.Operator, Text = "+" },
                new Token { Type = TokenType.Number, Text = "2" },
                Token.Stop
            });
        
        Assert.Equal(3M, result);
    }

    [Fact]
    public void Parse_TwoNumbersWithMinusOperatorBetween_ReturnSubOfThoseNumbers()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Number, Text = "2" },
                new Token { Type = TokenType.Operator, Text = "-" },
                new Token { Type = TokenType.Number, Text = "1" },
                Token.Stop
            });
        
        Assert.Equal(1M, result);
    }

    [Fact]
    public void Parse_SumOfMultipleNumbers_ReturnSumOfThoseNumbers()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Number, Text = "1" },
                new Token { Type = TokenType.Operator, Text = "+" },
                new Token { Type = TokenType.Number, Text = "2" },
                new Token { Type = TokenType.Operator, Text = "+" },
                new Token { Type = TokenType.Number, Text = "3" },
                Token.Stop
            });
        
        Assert.Equal(6M, result);
    }

    [Fact]
    public void Parse_SubOfMultipleNumbers_ReturnSubOfThoseNumbers()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Number, Text = "6" },
                new Token { Type = TokenType.Operator, Text = "-" },
                new Token { Type = TokenType.Number, Text = "3" },
                new Token { Type = TokenType.Operator, Text = "-" },
                new Token { Type = TokenType.Number, Text = "2" },
                Token.Stop
            });
        
        Assert.Equal(1M, result);
    }

    [Fact]
    public void Parse_NumberMultNumber_ReturnsNumberTimesNumber()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Number, Text = "5" },
                new Token { Type = TokenType.Operator, Text = "*" },
                new Token { Type = TokenType.Number, Text = "2" },
                Token.Stop
            });
        
        Assert.Equal(10M, result);
    }
}