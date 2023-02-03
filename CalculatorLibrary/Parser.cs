using System.Globalization;

namespace CalculatorLibrary;

public class Parser
{
    public decimal Parse(IEnumerable<Token> tokens)
    {
        tokens = tokens.ToList();
        if (!tokens.Any())
            return 0;
        
        return tokens.First().Type == TokenType.Number
            ? decimal.Parse(tokens.First().Text, CultureInfo.InvariantCulture)
            : 0;
    }
}