using Frognar.MathCalc.Enums;

namespace Frognar.MathCalc.Expressions;

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
        if (--parens < 0)
            expression.AddError("Syntax error: Expr. ')' before '('");
        
        expression.AddOperator(")");
    }

    public void CompleteExpression()
    {
        AssertCorrectNumberOfParens();
        expression.Complete();
    }

    void AssertCorrectNumberOfParens()
    {
        switch (parens)
        {
            case > 0:
                expression.AddError($"Syntax error: Expr. Missing {parens} ')'");
                break;
            case < 0:
                expression.AddError($"Syntax error: Expr. ')' before '('");
                break;
        }
    }

    public void SetExprError(ParserState state, ParserEvent parserEvent, int line, int position)
        => expression.AddError($"Syntax error: Expr. {state}|{parserEvent}. line {line}, position {position}.");
}