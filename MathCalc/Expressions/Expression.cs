namespace Frognar.MathCalc.Expressions;

public class Expression
{
    readonly Dictionary<string, int> precedences = new()
    {
        { "(", 0 },
        { "+", 1 },
        { "-", 1 },
        { "*", 2 },
        { "/", 2 },
        { "^", 3 },
        { "~", 4 },
    };

    readonly HashSet<string> rightAssociativities = new()
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

    bool Compare(string input, string stack)
    {
        return input == "(" 
               || precedences[input] > precedences[stack]
               || precedences[input] == precedences[stack] && rightAssociativities.Contains(input);
    }

    public override string ToString() => expression;
}