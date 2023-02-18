using Frognar.MathCalc.Enums;
using Frognar.MathCalc.Expressions;

namespace Frognar.MathCalc;

public class Calculator
{
    string expression;
    
    public Calculator(string expression)
    {
        this.expression = expression;
    }

    public Calculator() : this("")
    {
    }

    public double Evaluate(string expression)
    {
        Builder builder = new ExpressionBuilder();
        Parser parser = new(builder);
        Lexer lexer = new(parser);
        
        lexer.Lex(expression);
        parser.HandleEvent(ParserEvent.EOF, -1, -1);

        Evaluator evaluator = new(builder.GetExpression());
        return evaluator.Evaluate();
    }

    public double Evaluate()
    {
        Builder builder = new ExpressionBuilder();
        Parser parser = new(builder);
        Lexer lexer = new(parser);
        
        lexer.Lex(expression);
        parser.HandleEvent(ParserEvent.EOF, -1, -1);

        Evaluator evaluator = new(builder.GetExpression());
        return evaluator.Evaluate();
    }
}