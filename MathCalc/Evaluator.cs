using System.Data;
using System.Globalization;
using Frognar.MathCalc.Expressions;

namespace Frognar.MathCalc;

internal class Evaluator
{
    readonly Expression expression;

    public Evaluator(Expression expression)
    {
        this.expression = expression;
    }

    public double Evaluate()
    {
        string error = expression.GetError();
        if (string.IsNullOrEmpty(error) == false)
            throw new InvalidExpressionException(error);

        return EvaluateExpression();
    }

    double EvaluateExpression()
    {
        Stack<double> numbers = new();
        string[] expr = expression.ToString().Split(' ');
        foreach (string x in expr)
        {
            if (double.TryParse(x, CultureInfo.InvariantCulture, out double number))
            {
                numbers.Push(number);
            }
            else
            {
                switch (x)
                {
                    case "~":
                        numbers.Push(numbers.Pop() * -1);
                        break;
                    case "+":
                        numbers.Push(numbers.Pop() + numbers.Pop());
                        break;
                    case "-":
                        double subtrahend = numbers.Pop();
                        numbers.Push(numbers.Pop() - subtrahend);
                        break;
                    case "*":
                        numbers.Push(numbers.Pop() * numbers.Pop());
                        break;
                    case "/":
                        double divisor = numbers.Pop();
                        numbers.Push(numbers.Pop() / divisor);
                        break;
                    case "^":
                        double exponent = numbers.Pop();
                        numbers.Push(Math.Pow(numbers.Pop(), exponent));
                        break;
                    case "SIN":
                        numbers.Push(Math.Sin(numbers.Pop()));
                        break;
                    case "COS":
                        numbers.Push(Math.Cos(numbers.Pop()));
                        break;
                }
            }
        }
 
        return numbers.Pop();
    }
}