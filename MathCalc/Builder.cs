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
}