namespace Frognar.MathCalc.Expressions;

internal class Expression
{
    readonly List<string> errors = new();
    
    readonly Dictionary<string, int> precedences = new()
    {
        { "+", 1 },
        { "-", 1 },
        { "*", 2 },
        { "/", 2 },
        { "^", 3 },
        { "~", 4 },
    };

    readonly HashSet<string> rightAssociativeOperators = new()
    {
        "^"
    };
    
    readonly Stack<string> operators = new();
    string expression = "";

    public void Complete()
    {
        while (operators.Count > 0)
            expression += $"{operators.Pop()} ";

        expression = expression.Trim();
    }
    
    public void AddNumber(string number) => expression += number + " ";

    public void AddOperator(string o)
    {
        try
        {
            AddOperatorToStack(o);
        }
        catch
        {
            // ignored
        }
    }

    void AddOperatorToStack(string o)
    {
        if (operators.Any())
            AddAnotherOperatorToStack(o);
        else
            operators.Push(o);
    }

    void AddAnotherOperatorToStack(string o)
    {
        if (operators.Peek() == "(")
        {
            operators.Push(o);
        }
        else if (o == ")")
        {
            HandleClosedParen();
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

    void HandleClosedParen()
    {
        while (operators.Peek() != "(")
            expression += operators.Pop() + " ";

        operators.Pop();
    }

    bool Compare(string input, string stack)
    {
        int inputValue = precedences.GetValueOrDefault(input, 0);
        int stackValue = precedences.GetValueOrDefault(stack, 0);
        return input == "(" 
               || inputValue > stackValue
               || inputValue == stackValue && rightAssociativeOperators.Contains(input);
    }

    public override string ToString() => expression;

    public void AddError(string error) => errors.Add(error);
    
    public string GetError() => errors.FirstOrDefault("");
}