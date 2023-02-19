using Frognar.MathCalc;
using Frognar.MathCalc.Enums;
using Frognar.MathCalc.Expressions;

namespace MathCalc.UnitTests;

public class ParserTests
{
    readonly Lexer lexer;
    readonly Builder builder;
    readonly Parser parser;

    protected ParserTests()
    {
        builder = new ExpressionBuilder();
        parser = new Parser(builder);
        lexer = new Lexer(parser);
    }

    void AssertParseResult(string expression, string expected)
    {
        lexer.Lex(expression);
        parser.HandleEvent(ParserEvent.EOF, -1, -1);
        Assert.Equal(expected, builder.GetExpression().ToString());
    }

    void AssertParseError(string expression, string expected)
    {
        lexer.Lex(expression);
        parser.HandleEvent(ParserEvent.EOF, -1, -1);
        Assert.Equal(expected, builder.GetExpression().GetError());
    }

    public class IncrementalTests : ParserTests
    {
        [Fact]
        public void Parse_X()
        {
            AssertParseResult("123", "123");
        }

        [Fact]
        public void Parse_MinusX()
        {
            AssertParseResult("-123", "123 ~");
        }

        [Fact]
        public void Parse_XMinusY()
        {
            AssertParseResult("123 - 23", "123 23 -");
        }

        [Fact]
        public void Parse_XPlusY()
        {
            AssertParseResult("100 + 23", "100 23 +");
        }

        [Fact]
        public void Parse_XPlusMinusY()
        {
            AssertParseResult("100 + -23", "100 23 ~ +");
        }

        [Fact]
        public void Parse_XTimesY()
        {
            AssertParseResult("10 * 5", "10 5 *");
        }

        [Fact]
        public void Parse_XTimesYPlusZ()
        {
            AssertParseResult("10 * 2 + 5", "10 2 * 5 +");
        }

        [Fact]
        public void Parse_XDividedByY()
        {
            AssertParseResult("10 / 2", "10 2 /");
        }

        [Fact]
        public void Parse_XDividedByMinusY()
        {
            AssertParseResult("10 / -2", "10 2 ~ /");
        }

        [Fact]
        public void Parse_XTimesMinusY()
        {
            AssertParseResult("10 * -2", "10 2 ~ *");
        }

        [Fact]
        public void Parse_XTimexYPlusMinusZ()
        {
            AssertParseResult("10 * 2 + -5", "10 2 * 5 ~ +");
        }

        [Fact]
        public void Parse_XToPowerOfY()
        {
            AssertParseResult("10 ^ 2", "10 2 ^");
        }

        [Fact]
        public void Parse_XToPowerOfMinusY()
        {
            AssertParseResult("10 ^ -2", "10 2 ~ ^");
        }

        [Fact]
        public void Parse_XTimeYPlusZInParen()
        {
            AssertParseResult("10 * (1 + 1)", "10 1 1 + *");
        }

        [Fact]
        public void Parse_ComplexExpression()
        {
            AssertParseResult("10 + ( 3 * 2 ) ^ 2 ^ -3 - 25 / 5", "10 3 2 * 2 3 ~ ^ ^ + 25 5 / -");
        }

        [Fact]
        public void Parse_StartWithParen()
        {
            AssertParseResult("(1 + 1) * 2", "1 1 + 2 *");
        }
    }

    public class ErrorTests : ParserTests
    {
        [Fact]
        public void Parse_Nothing()
        {
            AssertParseError("", "Syntax error: Expr. Expr|EOF. line -1, position -1.");
        }

        [Fact]
        public void Parse_TwoNumbersInRow()
        {
            AssertParseError("12 12", "Syntax error: Expr. Number|Number. line 1, position 3.");
        }

        [Fact]
        public void Parse_OperatorOnStart()
        {
            AssertParseError("^ 12", "Syntax error: Expr. Expr|ExponentSymbol. line 1, position 0.");
        }

        [Fact]
        public void Parse_ClosedParenAfterOpenParen()
        {
            AssertParseError("()", "Syntax error: Expr. Operator|ClosedParen. line 1, position 1.");
        }

        [Fact]
        public void Parse_OpenParenAfterNumber()
        {
            AssertParseError("12 (1 + 2)", "Syntax error: Expr. Number|OpenParen. line 1, position 3.");
        }

        [Fact]
        public void Parse_MissingClosedParen()
        {
            AssertParseError("12 * (1 + 1", 
                "Syntax error: Expr. Number|EOF. line -1, position -1. Missing 1 ')'");
        }

        [Fact]
        public void Parse_MissingOpenParen()
        {
            AssertParseError("12 * 1 + 1)", 
                "Syntax error: Expr. Number|ClosedParen. line 1, position 10. ')' before '('");
        }
        
        [Fact]
        public void Parse_ClosedParenBeforeOpenParen()
        {
            AssertParseError("12 * 1) + (1", 
                "Syntax error: Expr. Number|ClosedParen. line 1, position 6. ')' before '('");
        }
    }

    public class UnknownTests : ParserTests
    {
        [Theory]
        [InlineData("{", "Syntax error: Expr. Expr|OpenBrace. line 1, position 0. Unknown token.")]
        public void Parse_UnknownToken(string token, string expectedError)
        {
            AssertParseError(token, expectedError);
        }
    }
}