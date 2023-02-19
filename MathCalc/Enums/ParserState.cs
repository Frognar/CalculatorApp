namespace Frognar.MathCalc.Enums;

internal enum ParserState
{
    Expr,
    Number,
    Operator,
    End,
    Function
}