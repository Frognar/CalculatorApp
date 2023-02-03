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
            if (tokens[currentToken].Text == "+")
            {
                currentToken++;
                result += Number();
            }
            else if (tokens[currentToken].Text == "-")
            {
                currentToken++;
                result -= Number();
            }
            else
            {
                break;
            }
        }
        
        return result;
    }

    decimal Term()
    {
        decimal result = Number();
        if (tokens[currentToken].Text == "*")
        {
            currentToken++;
            result *= Number();
        }

        return result;
    }

    decimal Number()
    {
        decimal result = decimal.Parse(tokens[currentToken].Text, CultureInfo.InvariantCulture);
        currentToken++;
        return result;
    }
}