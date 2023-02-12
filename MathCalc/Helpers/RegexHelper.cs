using System.Text.RegularExpressions;

namespace Frognar.MathCalc.Helpers;

public static partial class RegexHelper
{
    public static readonly Regex WhiteSpacesPattern = WhiteSpaceRegex();
    public static readonly Regex NumberPattern = NumberRegex();
    public static readonly Regex NamePattern = NameRegex();
    
    [GeneratedRegex("^\\s+")]
    private static partial Regex WhiteSpaceRegex();

    [GeneratedRegex("^[0-9]+\\.?[0-9]*")]
    private static partial Regex NumberRegex();
    
    [GeneratedRegex("^\\w+")]
    private static partial Regex NameRegex();
}