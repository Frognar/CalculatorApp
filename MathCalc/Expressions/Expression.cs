namespace Frognar.MathCalc.Expressions;

internal class Expression
{
    readonly List<string> errors = new();
    
    readonly Dictionary<string, int> precedences = new()
    {
        { "SIN", 0 },
        { "(", 0 },
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
            if (operators.Any())
            {
                if (operators.Peek() == "(")
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
        catch
        {
            // ignored
        }
    }

    bool Compare(string input, string stack)
    {
        return input == "(" 
               || precedences[input] > precedences[stack]
               || precedences[input] == precedences[stack] && rightAssociativeOperators.Contains(input);
    }

    public override string ToString() => expression;

    public void AddError(string error) => errors.Add(error);
    
    public string GetError() => errors.FirstOrDefault("");
}