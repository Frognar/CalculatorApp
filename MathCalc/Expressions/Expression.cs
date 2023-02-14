namespace Frognar.MathCalc.Expressions;

public interface Expression
{
    public double Evaluate();
}

public record Expr(Term Term) : Expression
{
    public virtual double Evaluate() => Term.Evaluate();
}

public record AddExpr(Term Term, Expr Expr) : Expr(Term)
{
    public override double Evaluate() => Term.Evaluate() + Expr.Evaluate();
}

public record SubExpr(Term Term, Expr Expr) : Expr(Term)
{
    public override double Evaluate() => Term.Evaluate() - Expr.Evaluate();
}

public record Term(Factor Factor) : Expression
{
    public virtual double Evaluate() => Factor.Evaluate();
}

public record MulTerm(Factor Factor, Term Term) : Term(Factor)
{
    public override double Evaluate() => Factor.Evaluate() * Term.Evaluate();
}

public record DivTerm(Factor Factor, Term Term) : Term(Factor)
{
    public override double Evaluate() => Factor.Evaluate() / Term.Evaluate();
}

public record Factor(Base Base) : Expression
{
    public virtual double Evaluate() => Base.Evaluate();
}

public record PowFactor(Base Base, Factor Factor) : Factor(Base)
{
    public override double Evaluate() => Math.Pow(Base.Evaluate(), Factor.Evaluate());
}

public abstract record Base : Expression
{
    public abstract double Evaluate();
}

public record Number(double Num) : Base
{
    public override double Evaluate() => Num;
}

public record NegativeBase(Base Base) : Base
{
    public override double Evaluate() => -Base.Evaluate();
}

public record ExprBase(Expr Expr) : Base
{
    public override double Evaluate() => Expr.Evaluate();
}