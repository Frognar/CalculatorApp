namespace Frognar.MathCalc;

public class ExpressionBuilder : Builder
{
    List<string> operators = new();
    public string GetExpression()
    {
        if (operators.Count > 0)
            return $"123 {operators[0]}";
        return "123";
    }

    public void SetNumber(string number)
    {
    }

    public void SetMinus()
    {
        operators.Add("-");
    }
}