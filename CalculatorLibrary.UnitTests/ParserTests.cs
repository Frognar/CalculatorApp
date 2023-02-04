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

    [Fact]
    public void Parse_NumberDivNumber_ReturnsNumberDivByNumber()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Number, Text = "10" },
                new Token { Type = TokenType.Operator, Text = "/" },
                new Token { Type = TokenType.Number, Text = "2" },
                Token.Stop
            });
        
        Assert.Equal(5M, result);
    }

    [Fact]
    public void Parse_MultipleNumberMultiplication_ReturnsResultOfMultiplyingTheseNumbers()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Number, Text = "5" },
                new Token { Type = TokenType.Operator, Text = "*" },
                new Token { Type = TokenType.Number, Text = "2" },
                new Token { Type = TokenType.Operator, Text = "*" },
                new Token { Type = TokenType.Number, Text = "2" },
                Token.Stop
            });
        
        Assert.Equal(20M, result);
    }

    [Fact]
    public void Parse_MultipleNumberDividing_ReturnsResultOfDividingTheseNumbers()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Number, Text = "20" },
                new Token { Type = TokenType.Operator, Text = "/" },
                new Token { Type = TokenType.Number, Text = "2" },
                new Token { Type = TokenType.Operator, Text = "/" },
                new Token { Type = TokenType.Number, Text = "2" },
                Token.Stop
            });
        
        Assert.Equal(5M, result);
    }

    [Fact]
    public void Parse_MixedSumWithMult_ReturnsResultGivenTheOrderOfOperations()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Number, Text = "6" },
                new Token { Type = TokenType.Operator, Text = "+" },
                new Token { Type = TokenType.Number, Text = "2" },
                new Token { Type = TokenType.Operator, Text = "*" },
                new Token { Type = TokenType.Number, Text = "2" },
                Token.Stop
            });
        
        Assert.Equal(10M, result);
    }

    [Fact]
    public void Parse_MixedSubWithDiv_ReturnsResultGivenTheOrderOfOperations()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Number, Text = "9" },
                new Token { Type = TokenType.Operator, Text = "-" },
                new Token { Type = TokenType.Number, Text = "2" },
                new Token { Type = TokenType.Operator, Text = "/" },
                new Token { Type = TokenType.Number, Text = "2" },
                Token.Stop
            });
        
        Assert.Equal(8M, result);
    }

    [Fact]
    public void Parse_xToPowerOfY_ReturnsExponentiationResult()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Number, Text = "3" },
                new Token { Type = TokenType.Operator, Text = "^" },
                new Token { Type = TokenType.Number, Text = "3" },
                Token.Stop
            });

        Assert.Equal(27M, result);
    }

    [Fact]
    public void Parse_xToPowerOfYToPowerOfZ_ReturnsExponentiationResult()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Number, Text = "2" },
                new Token { Type = TokenType.Operator, Text = "^" },
                new Token { Type = TokenType.Number, Text = "2" },
                new Token { Type = TokenType.Operator, Text = "^" },
                new Token { Type = TokenType.Number, Text = "3" },
                Token.Stop
            });

        Assert.Equal(256M, result);
    }

    [Fact]
    public void Parse_xTimesYToPowerOfZ_CalculateExponentiationFirst()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {

                new Token { Type = TokenType.Number, Text = "2" },
                new Token { Type = TokenType.Operator, Text = "*" },
                new Token { Type = TokenType.Number, Text = "3" },
                new Token { Type = TokenType.Operator, Text = "^" },
                new Token { Type = TokenType.Number, Text = "2" },
                Token.Stop
            });
        
        Assert.Equal(18M, result);
    }

    [Fact]
    public void Parse_xDividedByYToPowerOfZ_CalculateExponentiationFirst()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {

                new Token { Type = TokenType.Number, Text = "81" },
                new Token { Type = TokenType.Operator, Text = "/" },
                new Token { Type = TokenType.Number, Text = "3" },
                new Token { Type = TokenType.Operator, Text = "^" },
                new Token { Type = TokenType.Number, Text = "2" },
                Token.Stop
            });
        
        Assert.Equal(9M, result);
    }

    [Fact]
    public void Parse_ExprWithinParenthesisTimesX_CalculateExprInParenthesisFirst()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Number, Text = "(" },
                new Token { Type = TokenType.Number, Text = "3" },
                new Token { Type = TokenType.Operator, Text = "+" },
                new Token { Type = TokenType.Number, Text = "3" },
                new Token { Type = TokenType.Number, Text = ")" },
                new Token { Type = TokenType.Operator, Text = "*" },
                new Token { Type = TokenType.Number, Text = "2" },
                Token.Stop
            });
        
        Assert.Equal(12M, result);
    }
}