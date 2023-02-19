using System.Globalization;
using Frognar.MathCalc.Enums;
using Frognar.MathCalc.Expressions;

namespace Frognar.MathCalc;

internal class Parser : TokenCollector
{
    int parens;
    readonly Builder builder;
    ParserState state = ParserState.Expr;
    readonly Dictionary<string, ParserEvent> functions = new()
    {
        { "SIN", ParserEvent.Sine },
        { "COS", ParserEvent.Cosine }
    };

    readonly Dictionary<string, string> variables = new()
    {
        { "PI", Math.PI.ToString(CultureInfo.InvariantCulture) },
        { "Π", Math.PI.ToString(CultureInfo.InvariantCulture) },
    };

    public Parser(Builder builder)
    {
        this.builder = builder;
    }

    public void OpenBrace(int line, int position) => HandleEventError(
        ParserEvent.OpenBrace, line, position, "Unknown token.");
    public void ClosedBrace(int line, int position) => HandleEventError(
        ParserEvent.ClosedBrace, line, position, "Unknown token.");
    public void OpenAngle(int line, int position) => HandleEventError(
        ParserEvent.OpenAngle, line, position, "Unknown token.");
    public void ClosedAngle(int line, int position) => HandleEventError(
        ParserEvent.ClosedAngle, line, position, "Unknown token.");
    public void Comma(int line, int position) => HandleEventError(
        ParserEvent.Comma, line, position, "Unknown token.");
    public void PercentSign(int line, int position) => HandleEventError(
        ParserEvent.PercentSign, line, position, "Unknown token.");
    public void Error(int line, int position) => HandleEventError(
        ParserEvent.Error, line, position, "Unknown token.");

    public void Name(string name, int line, int position)
    {
        name = name.ToUpper();
        if (functions.TryGetValue(name, out ParserEvent parserEvent))
            HandleEvent(parserEvent, line, position);
        else if (variables.TryGetValue(name, out string? value))
            Number(value, line, position);
        else
            HandleEventError(ParserEvent.Name, position, line);
    }

    public void OpenParen(int line, int position)
    {
        parens++;
        HandleEvent(ParserEvent.OpenParen, line, position);
    }

    public void ClosedParen(int line, int position)
    {
        if (--parens < 0)
            HandleEventError(ParserEvent.ClosedParen, line, position, "')' before '('.");
        
        HandleEvent(ParserEvent.ClosedParen, line, position);
    }

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
        new(ParserState.Expr, ParserEvent.Minus, ParserState.Operator, b => b.SetNegate()),
        new(ParserState.Expr, ParserEvent.OpenParen, ParserState.Operator, b => b.SetOpenParen()),
        new(ParserState.Expr, ParserEvent.Sine, ParserState.Function, b => b.SetFunction("SIN")),
        new(ParserState.Expr, ParserEvent.Cosine, ParserState.Function, b => b.SetFunction("COS")),
        
        new(ParserState.Number, ParserEvent.Minus, ParserState.Operator, b => b.SetMinus()),
        new(ParserState.Number, ParserEvent.Plus, ParserState.Operator, b => b.SetPlus()),
        new(ParserState.Number, ParserEvent.Asterisk, ParserState.Operator, b => b.SetAsterisk()),
        new(ParserState.Number, ParserEvent.Slash, ParserState.Operator, b => b.SetSlash()),
        new(ParserState.Number, ParserEvent.ExponentSymbol, ParserState.Operator, b => b.SetExponentSymbol()),
        new(ParserState.Number, ParserEvent.ClosedParen, ParserState.Number, b => b.SetClosedParen()),
        new(ParserState.Number, ParserEvent.EOF, ParserState.End, b => b.CompleteExpression()),
        
        new(ParserState.Operator, ParserEvent.Number, ParserState.Number, null),
        new(ParserState.Operator, ParserEvent.Minus, ParserState.Operator, b => b.SetNegate()),
        new(ParserState.Operator, ParserEvent.OpenParen, ParserState.Expr, b => b.SetOpenParen()),
        
        new(ParserState.Function, ParserEvent.OpenParen, ParserState.Expr, null)
    };

    public void HandleEvent(ParserEvent e, int line, int position)
    {
        if (e == ParserEvent.EOF)
            AssertCorrectNumberOfParens(e, line, position);
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

    
    void AssertCorrectNumberOfParens(ParserEvent e, int line, int position)
    {
        if (parens > 0)
            HandleEventError(e, line, position, $"Missing {parens} ')'.");
    }
    
    void HandleEventError(ParserEvent e, int line, int position, string? message = null)
    {
        builder.SetExprError(state, e, line, position, message);
    }

    public void Reset()
    {
        state = ParserState.Expr;
        builder.Reset();
    }
}