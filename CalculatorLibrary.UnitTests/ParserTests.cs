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
            new[]
            {
                new Token { Type = TokenType.Number, Text = "124.5" },
                Token.Stop
            });
        
        Assert.Equal(124.5M, result);
    }

    [Fact]
    public void Parse_MissingStopToken_ThrowsException()
    {
        Parser parser = new();

        Assert.Throws<Exception>(
            () => parser.Parse(
                new[]
                {
                    new Token { Type = TokenType.Number, Text = "1" }
                }));
    }

    [Fact]
    public void Parse_XPlusY_ReturnsTotal()
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
    public void Parse_XMinusY_ReturnsDifference()
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
    public void Parse_AdditionOfMultipleNumbers_ReturnsTotal()
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
    public void Parse_SubtractionOfMultipleNumbers_ReturnsDifference()
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
    public void Parse_XTimesY_ReturnsProduct()
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
    public void Parse_XDividedByY_ReturnsQuotient()
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
    public void Parse_MultiplicationOfMultipleNumber_ReturnsProduct()
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
    public void Parse_DivisionOfMultipleNumber_ReturnsQuotient()
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
    public void Parse_XPlusYTimesZ_CalculateMultiplicationFirst()
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
    public void Parse_XMinusYDividedByZ_CalculateDivisionFirst()
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
    public void Parse_XToPowerOfY_ReturnsExponentiationResult()
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
    public void Parse_XToPowerOfYToPowerOfZ_CalculateYToPowerOfZFirst()
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
    public void Parse_XTimesYToPowerOfZ_CalculateExponentiationFirst()
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
    public void Parse_XDividedByYToPowerOfZ_CalculateExponentiationFirst()
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
    public void Parse_ExpressionWithinParenthesisTimesX_CalculateExpressionInParenthesisFirst()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Operator, Text = "(" },
                new Token { Type = TokenType.Number, Text = "3" },
                new Token { Type = TokenType.Operator, Text = "+" },
                new Token { Type = TokenType.Number, Text = "3" },
                new Token { Type = TokenType.Operator, Text = ")" },
                new Token { Type = TokenType.Operator, Text = "*" },
                new Token { Type = TokenType.Number, Text = "2" },
                Token.Stop
            });
        
        Assert.Equal(12M, result);
    }

    [Fact]
    public void Parse_MinusX_ReturnsXTimesMinusOne()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Operator, Text = "-" },
                new Token { Type = TokenType.Number, Text = "3" },
                Token.Stop
            });
        
        Assert.Equal(-3M, result);
    }

    [Fact]
    public void Parse_ComplexExpression_ReturnsResultGivenOperationOrder()
    {
        Parser parser = new();

        decimal result = parser.Parse(
            new[]
            {
                new Token { Type = TokenType.Operator, Text = "-" },
                new Token { Type = TokenType.Operator, Text = "(" },
                new Token { Type = TokenType.Number, Text = "10." },
                new Token { Type = TokenType.Operator, Text = "+" },
                new Token { Type = TokenType.Operator, Text = "(" },
                new Token { Type = TokenType.Number, Text = "3" },
                new Token { Type = TokenType.Operator, Text = "*" },
                new Token { Type = TokenType.Number, Text = "2" },
                new Token { Type = TokenType.Operator, Text = ")" },
                new Token { Type = TokenType.Operator, Text = "^" },
                new Token { Type = TokenType.Number, Text = "2" },
                new Token { Type = TokenType.Operator, Text = "^" },
                new Token { Type = TokenType.Number, Text = "3" },
                new Token { Type = TokenType.Operator, Text = "-" },
                new Token { Type = TokenType.Number, Text = "25" },
                new Token { Type = TokenType.Operator, Text = "/" },
                new Token { Type = TokenType.Number, Text = "5" },
                new Token { Type = TokenType.Operator, Text = ")" },
                new Token { Type = TokenType.Operator, Text = "-" },
                new Token { Type = TokenType.Number, Text = ".05" },
                Token.Stop
            });
        
        Assert.Equal(-1679621.05M, result);
    }

    [Fact]
    public void Parse_MissingClosingParenthesis_ThrowsException()
    {
        Parser parser = new();
        Token[] tokens = {
            new() { Type = TokenType.Operator, Text = "-" },
            new() { Type = TokenType.Operator, Text = "(" },
            new() { Type = TokenType.Number, Text = "10." },
            new() { Type = TokenType.Operator, Text = "+" },
            new() { Type = TokenType.Number, Text = "3" },
            Token.Stop
        };

        Assert.Throws<Exception>(() => parser.Parse(tokens));
    }

    [Fact]
    public void Parse_XMinusMinusY_ReturnsXPlusY()
    {
        Parser parser = new();
        Token[] tokens = {
            new() { Type = TokenType.Number, Text = "10." },
            new() { Type = TokenType.Operator, Text = "-" },
            new() { Type = TokenType.Operator, Text = "-" },
            new() { Type = TokenType.Number, Text = "3" },
            Token.Stop
        };

        Assert.Equal(13M, parser.Parse(tokens));
    }

    [Theory]
    [InlineData("+", "+")]
    [InlineData("+", "*")]
    [InlineData("+", "/")]
    [InlineData("+", "^")]
    [InlineData("-", "+")]
    [InlineData("-", "*")]
    [InlineData("-", "/")]
    [InlineData("-", "^")]
    [InlineData("*", "+")]
    [InlineData("*", "*")]
    [InlineData("*", "/")]
    [InlineData("*", "^")]
    [InlineData("/", "+")]
    [InlineData("/", "*")]
    [InlineData("/", "/")]
    [InlineData("/", "^")]
    [InlineData("^", "+")]
    [InlineData("^", "*")]
    [InlineData("^", "/")]
    [InlineData("^", "^")]
    public void Parse_TwoOperatorsInRow_ThrowsException(string op1, string op2)
    {
        Parser parser = new();
        Token[] tokens = {
            new() { Type = TokenType.Number, Text = "10." },
            new() { Type = TokenType.Operator, Text = op1 },
            new() { Type = TokenType.Operator, Text = op2 },
            new() { Type = TokenType.Number, Text = "3" },
            Token.Stop
        };

        Assert.Throws<Exception>(() => parser.Parse(tokens));
    }
}