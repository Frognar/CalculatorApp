using Frognar.MathCalc.Enums;
using Frognar.MathCalc.Expressions;

namespace Frognar.MathCalc;

public class ExpressionBuilder : Builder
{
    int parens;
    readonly Expression expression = new();
    public Expression GetExpression() => expression;
    public void SetNumber(string number) => expression.AddNumber(number);
    public void SetMinus() => expression.AddOperator("-");
    public void SetNagate() => expression.AddOperator("~");
    public void SetPlus() => expression.AddOperator("+");
    public void SetAsterisk() => expression.AddOperator("*");
    public void SetSlash() => expression.AddOperator("/");
    public void SetExponentSymbol() => expression.AddOperator("^");
    public void SetOpenParen()
    {
        parens++;
        expression.AddOperator("(");
    }

    public void SetClosedParen()
    {
        parens--;
        expression.AddOperator(")");
    }

    public void CompleteExpression()
    {
        if (parens > 0)
            expression.AddError($"Syntax error: Expr. Missing {parens} ')'");
        
        expression.Complete();
    }

    public void SetExprError(ParserState state, ParserEvent parserEvent, int line, int position)
        => expression.AddError($"Syntax error: Expr. {state}|{parserEvent}. line {line}, position {position}.");
}