using Frognar.MathCalc.Enums;
using Frognar.MathCalc.Expressions;

namespace Frognar.MathCalc;

public class Calculator
{
    readonly Builder builder;
    readonly Parser parser;
    readonly Lexer lexer;
    string expr;
    
    public Calculator(string expression)
    {
        expr = expression;
        builder = new ExpressionBuilder();
        parser = new Parser(builder);
        lexer = new Lexer(parser);
    }

    public Calculator() : this("")
    {
    }

    public double Evaluate(string expression)
    {
        expr = expression;
        return Evaluate();
    }

    public double Evaluate()
    {
        lexer.Lex(expr);
        parser.HandleEvent(ParserEvent.EOF, -1, -1);

        Evaluator evaluator = new(builder.GetExpression());
        return evaluator.Evaluate();
    }
}