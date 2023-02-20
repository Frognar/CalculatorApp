namespace Frognar.MathCalc.Enums;

internal enum ParserEvent
{
    Number,
    Minus,
    Plus,
    Asterisk,
    Slash,
    ExponentSymbol,
    OpenParen,
    ClosedParen,
    EOF,
    OpenBrace,
    ClosedBrace,
    OpenAngle,
    ClosedAngle,
    Comma,
    PercentSign,
    Error,
    Sine,
    HyperbolicSine,
    Cosine,
    HyperbolicCosine,
    Tangent,
    AbsoluteValue,
    Name,
}