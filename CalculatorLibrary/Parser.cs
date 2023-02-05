using System.Globalization;

namespace CalculatorLibrary;

public class Parser
{
    List<Token> tokens = new();
    int currentToken;

    public decimal Parse(IEnumerable<Token> tokensToParse)
    {
        tokens = tokensToParse.ToList();
        currentToken = 0;
        if (tokens.Any() == false)
            return 0;

        if (tokens.Any(t => t.Type == TokenType.Stop) == false)
            throw new Exception();

        return Expr();
    }

    decimal Expr()
    {
        if (tokens[currentToken].Type == TokenType.Stop)
            return 0;
        
        decimal result = Term();
        while (true)
        {
            if (Match("+"))
                result += Term();
            else if (Match("-"))
                result -= Term();
            else
                break;
        }
        
        return result;
    }

    decimal Term()
    {
        decimal result = Factor();
        while (true)
        {
            if (Match("*"))
                result *= Factor();
            else if (Match("/"))
                result /= Factor();
            else
                break;
        }

        return result;
    }

    decimal Factor()
    {
        decimal result = Base();
        return Match("^") ? Pow(result, Factor()) : result;
    }

    static decimal Pow(decimal x, decimal y)
    {
        return (decimal)Math.Pow((double)x, (double)y);
    }

    decimal Base()
    {
        if (Match("("))
        {
            decimal result = Expr();
            if (Match(")") == false)
                throw new Exception("Missing ')'");

            return result;
        }

        return Match("-") ? -1 * Base() : Number();
    }

    decimal Number()
    {
        if (tokens[currentToken].Type != TokenType.Number)
            throw new Exception("Invalid token!");
        
        return decimal.Parse(tokens[currentToken++].Text, CultureInfo.InvariantCulture);
    }

    bool Match(string op)
    {
        if (tokens[currentToken].Text != op)
            return false;
        
        currentToken++;
        return true;
    }
}