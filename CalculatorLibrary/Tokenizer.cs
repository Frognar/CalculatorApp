namespace CalculatorLibrary;

public class Tokenizer
{
    enum State { None, Number }
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
                    
                    if (digits.Contains(expression[i]))
                    {
                        state = State.Number;
                        tokenPosition = i;
                    }
                    else
                    {
                        tokens.Add(new Token
                        {
                            Type = TokenType.Operator,
                            Text = expression.Substring(tokenPosition)
                        });
                    }
                    
                    break;
                
                case State.Number:
                    if (expression[i] == ' ')
                    {
                        tokens.Add(new Token
                        {
                            Type = TokenType.Number,
                            Text = expression.Substring(tokenPosition, i)
                        });
                        
                        state = State.None;
                    }
                    break;
            }
            
            if (i == expression.Length - 1 && state != State.None)
                tokens.Add(new Token
                {
                    Type = state switch
                    {
                        State.Number => TokenType.Number,
                        _ => throw new ArgumentException()
                    },
                    Text = expression.Substring(tokenPosition)
                });
        }

        tokens.Add(Token.Stop);
        return tokens;
    }
}