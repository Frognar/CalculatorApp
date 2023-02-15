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
        AddOperator("-");
    }

    public void SetNagate()
    {
        AddOperator("~");
    }

    public void SetPlus()
    {
        AddOperator("+");
    }

    public void SetAsterisk()
    {
        AddOperator("*");
    }

    public void SetSlash()
    {
        AddOperator("/");
    }

    public void SetExponentSymbol()
    {
        AddOperator("^");
    }

    void AddOperator(string o)
    {
        if (operators.Any())
        {
            if (o == "(")
            {
                operators.Push(o);
            }
            else if (o == ")")
            {
                while (operators.Peek() != "(")
                    expression += operators.Pop() + " ";

                operators.Pop();
            }
            else if (Compare(o, operators.Peek()))
            {
                operators.Push(o);
            }
            else
            {
                while (Compare(o, operators.Peek()) == false)
                {
                    expression += operators.Pop() + " ";
                    if (operators.Any() == false)
                        break;
                }
                
                operators.Push(o);
            }
        }
        else
        {
            operators.Push(o);
        }
    }

    static bool Compare(string input, string stack)
    {
        if (input == "(")
            return true;
        
        Dictionary<string, int> values = new()
        {
            { "+", 1 },
            { "-", 1 },
            { "*", 2 },
            { "/", 2 },
            { "^", 3 },
            { "~", 4 },
        };

        return values[input] > values[stack];
    }
}