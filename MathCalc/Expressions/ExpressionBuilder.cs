using Frognar.MathCalc.Enums;

namespace Frognar.MathCalc.Expressions;

internal class ExpressionBuilder : Builder
{
    Expression expression = new();
    public Expression GetExpression() => expression;
    public void SetNumber(string number) => expression.AddNumber(number);
    public void SetMinus() => expression.AddOperator("-");
    public void SetNegate() => expression.AddOperator("~");
    public void SetPlus() => expression.AddOperator("+");
    public void SetAsterisk() => expression.AddOperator("*");
    public void SetSlash() => expression.AddOperator("/");
    public void SetExponentSymbol() => expression.AddOperator("^");
    public void SetOpenParen() => expression.AddOperator("(");
    public void SetClosedParen() => expression.AddOperator(")");
    public void SetFunction(string function) => expression.AddOperator(function);
    public void CompleteExpression() => expression.Complete();
    public void Reset() => expression = new Expression();

    public void SetExprError(ParserState state, ParserEvent parserEvent, int line, int position, string? message = null)
        => expression.AddError(FormatMessage(state, parserEvent, line, position, message));

    static string FormatMessage(ParserState state, ParserEvent parserEvent, int line, int position, string? message) =>
        string.IsNullOrEmpty(message)
            ? $"Syntax error: Expr. {state}|{parserEvent}. line {line}, position {position}."
            : $"Syntax error: Expr. {state}|{parserEvent}. line {line}, position {position}. {message}";
}