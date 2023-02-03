using System.Globalization;

namespace CalculatorLibrary;

public class Parser
{
    List<Token> tokens = new();

    public decimal Parse(IEnumerable<Token> tokensToParse)
    {
        tokens = tokensToParse.ToList();
        if (tokens.Any() == false)
            return 0;

        if (tokens.Any(t => t.Type == TokenType.Stop) == false)
            throw new Exception();

        return Expr();
    }

    decimal Expr()
    {
        decimal result = tokens[0].Type == TokenType.Number
            ? decimal.Parse(tokens[0].Text, CultureInfo.InvariantCulture)
            : 0;

        return result;
    }
}