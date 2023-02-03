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

        return tokens.First().Type == TokenType.Number
            ? decimal.Parse(tokens.First().Text, CultureInfo.InvariantCulture)
            : 0;
    }
}