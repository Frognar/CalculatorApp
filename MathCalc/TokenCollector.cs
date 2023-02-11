namespace Frognar.MathCalc;

public interface TokenCollector
{
    void OpenBrace(int line, int position);
    void ClosedBrace(int line, int position);
    void OpenParen(int line, int position);
    void ClosedParen(int line, int position);
    void OpenAngle(int line, int position);
}