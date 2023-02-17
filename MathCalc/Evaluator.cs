using System.Data;
using Frognar.MathCalc.Expressions;

namespace Frognar.MathCalc;

public class Evaluator
{
    readonly Expression expression;
    

    public Evaluator(Expression expression)
    {
        this.expression = expression;
    }

    public double Evaluate()
    {
        if (string.IsNullOrEmpty(expression.GetError()) == false)
            throw new InvalidExpressionException();

        return EvaluateExpression();
    }

    double EvaluateExpression()
    {
        Stack<double> numbers = new();
        string[] expr = expression.ToString().Split(' ');
        foreach (string x in expr)
        {
            if (double.TryParse(x, out double number))
            {
                numbers.Push(number);
            }
            else
            {
                switch (x)
                {
                    case "+":
                        numbers.Push(numbers.Pop() + numbers.Pop());
                        break;
                }
            }
        }
 
        return numbers.Pop();
    }
}