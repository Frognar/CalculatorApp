using System.Globalization;
using Frognar.MathCalc.Expressions;

namespace Frognar.MathCalc;

public class ExpressionBuilder : Builder
{
    double? parsedNumber;
    public Expression GetExpression()
    {
        return new Number(parsedNumber.GetValueOrDefault(0));
    }

    public void SetNumber(string number)
    {
        parsedNumber = double.Parse(number, CultureInfo.InvariantCulture);
    }
}