﻿using System.Data;
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

    Expression GetExpression(string expression)
    {
        lexer.Lex(expression);
        parser.HandleEvent(ParserEvent.EOF, -1, -1);
        return builder.GetExpression();
    }

    void AssertEvaluation(string expression, double expected)
    {
        Evaluator evaluator = new(GetExpression(expression));
        Assert.Equal(expected, evaluator.Evaluate(), 0.0001);
    }
    
    [Fact]
    public void Evaluate_ExpressionWithErrors_ThrowInvalidExpressionException()
    {
        Evaluator evaluator = new(GetExpression(""));
        Assert.Throws<InvalidExpressionException>(() => evaluator.Evaluate());
    }

    [Fact]
    public void Evaluate_ExpressionWithSingleNumber()
    {
        AssertEvaluation("123", 123d);
    }
}