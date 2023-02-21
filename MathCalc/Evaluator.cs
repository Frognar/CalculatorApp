using System.Data;
using System.Globalization;
using Frognar.MathCalc.Evaluators;
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
                    case "+":
                    case "-":
                    case "*":
                        numbers.Push(EvaluatorProvider.GetEvaluator(x).Evaluate(numbers));
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
                    case "SINH":
                        numbers.Push(Math.Sinh(numbers.Pop()));
                        break;
                    case "COS":
                        numbers.Push(Math.Cos(numbers.Pop()));
                        break;
                    case "COSH":
                        numbers.Push(Math.Cosh(numbers.Pop()));
                        break;
                    case "TAN":
                        numbers.Push(Math.Tan(numbers.Pop()));
                        break;
                    case "TANH":
                        numbers.Push(Math.Tanh(numbers.Pop()));
                        break;
                    case "ABS":
                        numbers.Push(Math.Abs(numbers.Pop()));
                        break;
                }
            }
        }
 
        return numbers.Pop();
    }
}