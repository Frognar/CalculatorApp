using Frognar.MathCalc.Enums;

namespace Frognar.MathCalc;

public class Parser : TokenCollector
{
    readonly Builder builder;
    ParserState state = ParserState.Expr;

    public Parser(Builder builder)
    {
        this.builder = builder;
    }

    public void OpenBrace(int line, int position) => throw new NotImplementedException();
    public void ClosedBrace(int line, int position) => throw new NotImplementedException();
    public void OpenAngle(int line, int position) => throw new NotImplementedException();
    public void ClosedAngle(int line, int position) => throw new NotImplementedException();
    public void Comma(int line, int position) => throw new NotImplementedException();
    public void PercentSing(int line, int position) => throw new NotImplementedException();
    public void Name(string name, int line, int position) => throw new NotImplementedException();
    public void Error(int line, int position) => throw new NotImplementedException();

    public void OpenParen(int line, int position) => HandleEvent(ParserEvent.OpenParen, line, position);
    public void ClosedParen(int line, int position) => HandleEvent(ParserEvent.ClosedParen, line, position);
    public void MinusSign(int line, int position) => HandleEvent(ParserEvent.Minus, line, position);
    public void PlusSign(int line, int position) => HandleEvent(ParserEvent.Plus, line, position);
    public void ExponentSymbol(int line, int position) => HandleEvent(ParserEvent.ExponentSymbol, line, position);
    public void Asterisk(int line, int position) => HandleEvent(ParserEvent.Asterisk, line, position);
    public void Slash(int line, int position) => HandleEvent(ParserEvent.Slash, line, position);

    public void Number(string number, int line, int position)
    {
        builder.SetNumber(number);
        HandleEvent(ParserEvent.Number, line, position);
    }

    record Transition(ParserState ParserState, ParserEvent ParserEvent, ParserState NewState, Action<Builder>? Action);

    readonly Transition[] transitions =
    {
        new(ParserState.Expr, ParserEvent.Number, ParserState.Number, null),
        new(ParserState.Expr, ParserEvent.Minus, ParserState.Operator, b => b.SetNagate()),
        
        new(ParserState.Number, ParserEvent.Minus, ParserState.Operator, b => b.SetMinus()),
        new(ParserState.Number, ParserEvent.Plus, ParserState.Operator, b => b.SetPlus()),
        new(ParserState.Number, ParserEvent.Asterisk, ParserState.Operator, b => b.SetAsterisk()),
        new(ParserState.Number, ParserEvent.Slash, ParserState.Operator, b => b.SetSlash()),
        new(ParserState.Number, ParserEvent.ExponentSymbol, ParserState.Operator, b => b.SetExponentSymbol()),
        new(ParserState.Number, ParserEvent.ClosedParen, ParserState.Number, b => b.SetClosedParen()),
        new(ParserState.Number, ParserEvent.EOF, ParserState.End, b => b.CompleteExpression()),
        
        new(ParserState.Operator, ParserEvent.Number, ParserState.Number, null),
        new(ParserState.Operator, ParserEvent.Minus, ParserState.Operator, b => b.SetNagate()),
        new(ParserState.Operator, ParserEvent.OpenParen, ParserState.Expr, b => b.SetOpenParen())
    };

    public void HandleEvent(ParserEvent e, int line, int position)
    {
        foreach (Transition t in transitions)
        {
            if (t.ParserState != state || t.ParserEvent != e) 
                continue;
            
            state = t.NewState;
            t.Action?.Invoke(builder);
            return;
        }

        HandleEventError(e, line, position);
    }

    void HandleEventError(ParserEvent e, int line, int position)
    {
        builder.SetExprError(state, e, line, position);
    }
}