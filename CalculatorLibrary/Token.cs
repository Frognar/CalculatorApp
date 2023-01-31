namespace CalculatorLibrary;

public class Token
{
    public required TokenType Type { get; init; }
    public required string Text { get; init; }
}