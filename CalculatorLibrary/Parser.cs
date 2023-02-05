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
                result += Term();
            }
            else if (tokens[currentToken].Text == "-")
            {
                currentToken++;
                result -= Term();
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
        decimal result = Factor();
        while (true)
        {
            if (tokens[currentToken].Text == "*")
            {
                currentToken++;
                result *= Factor();
            }
            else if (tokens[currentToken].Text == "/")
            {
                currentToken++;
                result /= Factor();
            }
            else
            {
                break;
            }
        }

        return result;
    }

    decimal Factor()
    {
        decimal result = Base();
        if (tokens[currentToken].Text == "^")
        {
            currentToken++;
            result = (decimal)Math.Pow((double)result, (double)Factor());
        }
        
        return result;
    }

    decimal Base()
    {
        if (tokens[currentToken].Text == "(")
        {
            currentToken++;
            decimal result = Expr();
            if (tokens[currentToken].Text == ")")
            {
                currentToken++;
            }
            else
            {
                throw new Exception("Missing ')'");
            }

            return result;
        }

        if (tokens[currentToken].Text == "-")
        {
            currentToken++;
            return -1 * Base();
        }
        
        return Number();
    }

    decimal Number()
    {
        if (tokens[currentToken].Type != TokenType.Number)
            throw new Exception("Invalid token!");
        
        decimal result = decimal.Parse(tokens[currentToken].Text, CultureInfo.InvariantCulture);
        currentToken++;
        return result;
    }
}