using Frognar.MathCalc.Enums;
using Frognar.MathCalc.Expressions;

namespace Frognar.MathCalc;

public class ExpressionBuilder : Builder
{
    readonly Expression expression = new();
    public void SetNumber(string number) => expression.AddNumber(number);
    public void SetMinus() => expression.AddOperator("-");
    public void SetNagate() => expression.AddOperator("~");
    public void SetPlus() => expression.AddOperator("+");
    public void SetAsterisk() => expression.AddOperator("*");
    public void SetSlash() => expression.AddOperator("/");
    public void SetExponentSymbol() => expression.AddOperator("^");
    public void SetOpenParen() => expression.AddOperator("(");
    public void SetClosedParen() => expression.AddOperator(")");

    public Expression GetExpression()
    {
        expression.Complete();
        return expression;
    }
    
    public string GetError()
    {
        return expression.GetError();
    }
    
    public void SetExprError(ParserState state, ParserEvent parserEvent, int line, int position)
    {
        expression.AddError($"Syntax error: Expr. {state}|{parserEvent}. line {line}, position {position}.");
    }
}