namespace CalculatorLibrary;

public class Tokenizer
{
    enum State { None, Number, Operator }
    readonly char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    public IEnumerable<Token> Tokenize(string expression)
    {
        List<Token> tokens = new();
        State state = State.None;
        int tokenPosition = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            switch (state)
            {
                case State.None:
                    if (expression[i] == ' ')
                        break;
                    
                    tokenPosition = i;
                    state = digits.Contains(expression[i]) ? State.Number : State.Operator;
                    break;
                
                case State.Number:
                    if (digits.Contains(expression[i]))
                        break;
                    
                    tokens.Add(new Token
                    {
                        Type = TokenType.Number,
                        Text = expression.Substring(tokenPosition, i - tokenPosition)
                    });
                    
                    tokenPosition = i;
                    state = (expression[i] == ' ') ? State.None : State.Operator;
                    break;
                
                case State.Operator:
                    tokens.Add(new Token
                    {
                        Type = TokenType.Operator,
                        Text = expression[tokenPosition].ToString()
                    });
                    
                    tokenPosition = i;

                    if (expression[i] == ' ')
                        state = State.None;
                    else if (digits.Contains(expression[i]))
                        state = State.Number;
                    
                    break;
            }
            
            if (i == expression.Length - 1 && state != State.None)
                tokens.Add(new Token
                {
                    Type = state switch
                    {
                        State.Number => TokenType.Number,
                        State.Operator => TokenType.Operator,
                        _ => throw new ArgumentException()
                    },
                    Text = expression.Substring(tokenPosition)
                });
        }

        tokens.Add(Token.Stop);
        return tokens;
    }
}