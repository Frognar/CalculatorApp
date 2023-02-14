namespace Frognar.MathCalc;

public class ExpressionBuilder : Builder
{
    readonly List<string> operators = new();
    string expression = "";
    
    public string GetExpression()
    {
        if (operators.Count > 0)
            expression += operators[0];
        
        return expression.Trim();
    }

    public void SetNumber(string number)
    {
        expression += number + " ";
    }

    public void SetMinus()
    {
        operators.Add("-");
    }

    public void SetNagate()
    {
        operators.Add("~");
    }
}