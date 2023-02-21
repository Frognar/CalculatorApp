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
                    case "/":
                    case "^":
                    case "SIN":
                    case "SINH":
                    case "COS":
                    case "COSH":
                    case "TAN":
                    case "TANH":
                    case "ABS":
                        numbers.Push(EvaluatorProvider.GetEvaluator(x).Evaluate(numbers));
                        break;
                }
            }
        }
 
        return numbers.Pop();
    }
}