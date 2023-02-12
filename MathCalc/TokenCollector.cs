namespace Frognar.MathCalc;

public interface TokenCollector
{
    void OpenBrace(int line, int position);
    void ClosedBrace(int line, int position);
    void OpenParen(int line, int position);
    void ClosedParen(int line, int position);
    void OpenAngle(int line, int position);
    void ClosedAngle(int line, int position);
    void MinusSign(int line, int position);
    void PlusSign(int line, int position);
    void ExponentSymbol(int line, int position);
    void Asterisk(int line, int position);
    void Slash(int line, int position);
    void Comma(int line, int position);
}