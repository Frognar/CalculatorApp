namespace CalculatorLibrary;

public class Tokenizer
{
    enum State { None, Number, Operator }
    readonly char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    readonly List<Token> tokens = new();
    int position;
    State state;
    int tokenPosition;
    
    public IEnumerable<Token> Tokenize(string expression)
    {
        tokens.Clear();
        state = State.None;
        tokenPosition = 0;
        for (position = 0; position < expression.Length; position++)
        {
            switch (state)
            {
                case State.None:
                    if (expression[position] == ' ')
                        break;
                    
                    tokenPosition = position;
                    state = digits.Contains(expression[position]) ? State.Number : State.Operator;
                    break;
                
                case State.Number:
                    if (digits.Contains(expression[position]))
                        break;
                    
                    tokens.Add(new Token
                    {
                        Type = TokenType.Number,
                        Text = expression[tokenPosition..position]
                    });
                    
                    tokenPosition = position;
                    state = expression[position] == ' ' ? State.None : State.Operator;
                    break;
                
                case State.Operator:
                    tokens.Add(new Token
                    {
                        Type = TokenType.Operator,
                        Text = expression[tokenPosition..position]
                    });
                    
                    tokenPosition = position;
                    if (expression[position] == ' ')
                        state = State.None;
                    else if (digits.Contains(expression[position]))
                        state = State.Number;
                    
                    break;
            }
            
            if (position == expression.Length - 1 && state != State.None)
                tokens.Add(new Token
                {
                    Type = state switch
                    {
                        State.Number => TokenType.Number,
                        State.Operator => TokenType.Operator,
                        _ => throw new ArgumentException()
                    },
                    Text = expression[tokenPosition..]
                });
        }

        tokens.Add(Token.Stop);
        return tokens;
    }
}