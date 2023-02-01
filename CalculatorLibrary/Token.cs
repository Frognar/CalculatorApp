namespace CalculatorLibrary;

public class Token
{
    public static readonly Token Stop = new() { Type = TokenType.Stop, Text = "" };

    public required TokenType Type { get; init; }
    public required string Text { get; init; }
}