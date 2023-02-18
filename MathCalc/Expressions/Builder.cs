using Frognar.MathCalc.Enums;

namespace Frognar.MathCalc.Expressions;

internal interface Builder
{
    Expression GetExpression();
    void SetNumber(string number);
    void SetMinus();
    void SetNegate();
    void SetPlus();
    void SetAsterisk();
    void SetSlash();
    void SetExponentSymbol();
    void SetOpenParen();
    void SetClosedParen();
    void CompleteExpression();
    void SetExprError(ParserState state, ParserEvent parserEvent, int line, int position);
}