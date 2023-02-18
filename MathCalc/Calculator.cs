using Frognar.MathCalc.Enums;
using Frognar.MathCalc.Expressions;

namespace Frognar.MathCalc;

public class Calculator
{
    string expr;
    
    public Calculator(string expression)
    {
        expr = expression;
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
        Builder builder = new ExpressionBuilder();
        Parser parser = new(builder);
        Lexer lexer = new(parser);
        
        lexer.Lex(expr);
        parser.HandleEvent(ParserEvent.EOF, -1, -1);

        Evaluator evaluator = new(builder.GetExpression());
        return evaluator.Evaluate();
    }
}