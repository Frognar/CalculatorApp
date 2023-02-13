using Frognar.MathCalc;

namespace MathCalc.UnitTests;

public class ParserTests
{
    [Fact]
    public void CanCreateParser()
    {
        Builder builder = new ExpressionBuilder();
        TokenCollector parser = new Parser(builder);
    }
}