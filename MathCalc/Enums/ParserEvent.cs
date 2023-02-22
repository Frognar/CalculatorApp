namespace Frognar.MathCalc.Enums;

internal enum ParserEvent
{
    EOF,
    Number,
    Minus,
    Plus,
    Asterisk,
    Slash,
    ExponentSymbol,
    OpenParen,
    ClosedParen,
    OpenBrace,
    ClosedBrace,
    OpenAngle,
    ClosedAngle,
    Comma,
    PercentSign,
    Error,
    Name,
    Sine,
    HyperbolicSine,
    Cosine,
    HyperbolicCosine,
    Tangent,
    HyperbolicTangent,
    AbsoluteValue,
    SquareRoot,
    CubeRoot,
    Log2,
    Log10
}