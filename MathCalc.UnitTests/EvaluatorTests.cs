using System.Data;
using Frognar.MathCalc;
using Frognar.MathCalc.Enums;
using Frognar.MathCalc.Expressions;

namespace MathCalc.UnitTests;

public class EvaluatorTests
{
    Lexer lexer;
    Parser parser;
    Builder builder;

    public EvaluatorTests()
    {
        builder = new ExpressionBuilder();
        parser = new Parser(builder);
        lexer = new Lexer(parser);
    }
    
    [Fact]
    public void Evaluate_ExpressionWithErrors_ThrowInvalidExpressionException()
    {
        lexer.Lex("");
        parser.HandleEvent(ParserEvent.EOF, -1, -1);
        Expression expression = builder.GetExpression();
        Evaluator evaluator = new(expression);

        Assert.Throws<InvalidExpressionException>(() => evaluator.Evaluate());
    }

    [Fact]
    public void Evaluate_ExpressionWithSingleNumber()
    {
        lexer.Lex("123");
        parser.HandleEvent(ParserEvent.EOF, -1, -1);
        Expression expression = builder.GetExpression();
        Evaluator evaluator = new(expression);
        
        Assert.Equal(123d, evaluator.Evaluate(), 0.0001);
    }
}