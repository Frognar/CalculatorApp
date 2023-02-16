using Frognar.MathCalc;

namespace MathCalc.UnitTests;

public class ParserTests
{
    readonly Lexer lexer;
    readonly ExpressionBuilder builder;
    readonly Parser parser;

    public ParserTests()
    {
        builder = new ExpressionBuilder();
        parser = new Parser(builder);
        lexer = new Lexer(parser);
    }

    void AssertParseResult(string expression, string expected)
    {
        lexer.Lex(expression);
        
        Assert.Equal(expected, builder.GetExpression());
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
        public void Parse_XPlusMuinusY()
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
        public void Parse_XDevidedByY()
        {
            AssertParseResult("10 / 2", "10 2 /");
        }

        [Fact]
        public void Parse_XDevidedByMinusY()
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
    }
}