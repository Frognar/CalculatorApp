using Frognar.MathCalc.Enums;

namespace Frognar.MathCalc;

public class Parser : TokenCollector
{
    readonly Builder builder;
    ParserState state = ParserState.None;

    public Parser(Builder builder)
    {
        this.builder = builder;
    }

    public void OpenBrace(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void ClosedBrace(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void OpenParen(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void ClosedParen(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void OpenAngle(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void ClosedAngle(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void MinusSign(int line, int position)
    {
        HandleEvent(ParserEvent.Minus, line, position);
    }

    public void PlusSign(int line, int position)
    {
        HandleEvent(ParserEvent.Plus, line, position);
    }

    public void ExponentSymbol(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void Asterisk(int line, int position)
    {
        HandleEvent(ParserEvent.Asterisk, line, position);
    }

    public void Slash(int line, int position)
    {
        HandleEvent(ParserEvent.Slash, line, position);
    }

    public void Comma(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void PercentSing(int line, int position)
    {
        throw new NotImplementedException();
    }

    public void Name(string name, int line, int position)
    {
        throw new NotImplementedException();
    }

    public void Number(string number, int line, int position)
    {
        builder.SetNumber(number);
        HandleEvent(ParserEvent.Number, line, position);
    }

    public void Error(int line, int position)
    {
        throw new NotImplementedException();
    }

    record Transition(ParserState ParserState, ParserEvent ParserEvent, ParserState NewState, Action<Builder>? Action);

    readonly Transition[] transitions =
    {
        new(ParserState.None, ParserEvent.Number, ParserState.Number, null),
        new(ParserState.None, ParserEvent.Minus, ParserState.Minus, b => b.SetNagate()),
        
        new(ParserState.Number, ParserEvent.Minus, ParserState.Minus, b => b.SetMinus()),
        new(ParserState.Number, ParserEvent.Plus, ParserState.Plus, b => b.SetPlus()),
        new(ParserState.Number, ParserEvent.Asterisk, ParserState.Asterisk, b => b.SetAsterisk()),
        new(ParserState.Number, ParserEvent.Slash, ParserState.Asterisk, b => b.SetSlash()),
        
        new(ParserState.Minus, ParserEvent.Number, ParserState.Number, null),
        new(ParserState.Asterisk, ParserEvent.Number, ParserState.Number, null),
        new(ParserState.Plus, ParserEvent.Minus, ParserState.Minus, b => b.SetNagate())
        
    };

    void HandleEvent(ParserEvent e, int line, int position)
    {
        foreach (Transition t in transitions)
        {
            if (t.ParserState != state || t.ParserEvent != e) 
                continue;
            
            state = t.NewState;
            t.Action?.Invoke(builder);
            break;
        }
    }
}