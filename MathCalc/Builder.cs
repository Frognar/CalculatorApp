using Frognar.MathCalc.Enums;

namespace Frognar.MathCalc;

public interface Builder
{
    void SetNumber(string number);
    void SetMinus();
    void SetNagate();
    void SetPlus();
    void SetAsterisk();
    void SetSlash();
    void SetExponentSymbol();
    void SetOpenParen();
    void SetClosedParen();
    void CompleteExpression();
    void SetExprError(ParserState state, ParserEvent parserEvent, int line, int position);
}