namespace Frognar.MathCalc;

public class ExpressionBuilder : Builder
{
    readonly Stack<string> operators = new();
    string expression = "";
    
    public string GetExpression()
    {
        while (operators.Count > 0)
            expression += $"{operators.Pop()} ";
        
        return expression.Trim();
    }

    public void SetNumber(string number)
    {
        expression += number + " ";
    }

    public void SetMinus()
    {
        operators.Push("-");
    }

    public void SetNagate()
    {
        operators.Push("~");
    }

    public void SetPlus()
    {
        operators.Push("+");
    }
}