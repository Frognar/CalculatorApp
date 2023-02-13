namespace Frognar.MathCalc;

/*
 <EXPR> ::= <TERM> | <TERM> "+" <EXPR> | <TERM> "-" <EXPR>
 <TERM> ::= <FACTOR> | <FACTOR> "*" <TERM> | <FACTOR> "/" <TERM>
 <FACTOR> ::= <BASE> | <BASE> "^" <FACTOR>
 <BASE> ::= <NUMBER> | "-" <BASE> | "(" <EXPR> ")"
 */
public class Parser : TokenCollector
{
    public Parser(Builder builder)
    {
    }

    public void OpenBrace(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void ClosedBrace(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void OpenParen(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void ClosedParen(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void OpenAngle(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void ClosedAngle(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void MinusSign(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void PlusSign(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void ExponentSymbol(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void Asterisk(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void Slash(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void Comma(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void PercentSing(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void Name(string name, int line, int position)
    {
        throw new NotImplementedException();
    }

    public void Number(string number, int line, int position)
    {
        throw new NotImplementedException();
    }

    public void Error(int line, int position)
    {
        throw new NotImplementedException();
    }
}