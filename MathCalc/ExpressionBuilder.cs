using System.Globalization;
using Frognar.MathCalc.Expressions;

namespace Frognar.MathCalc;

public class ExpressionBuilder : Builder
{
    double? parsedNumber;
    bool isNegative;
    public Expression GetExpression()
    {
        double number = parsedNumber.GetValueOrDefault(0);
        return new Number(isNegative ? -number : number);
    }

    public void SetNumber(string number)
    {
        parsedNumber = double.Parse(number, CultureInfo.InvariantCulture);
    }

    public void SetMinus()
    {
        isNegative = true;
    }
}