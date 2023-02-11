namespace Frognar.MathCalc;

public interface TokenCollector
{
    void OpenBrace(int line, int position);
    void ClosedBrace(int line, int position);
}