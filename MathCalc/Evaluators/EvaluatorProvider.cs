namespace Frognar.MathCalc.Evaluators;

public static class EvaluatorProvider
{
    static readonly Dictionary<string, Evaluator> Evaluators = typeof(Evaluator)
        .Assembly
        .GetTypes()
        .Where(t => t is { IsInterface: false, IsAbstract: false } && typeof(Evaluator).IsAssignableFrom(t))
        .Select(t => (Evaluator)Activator.CreateInstance(t)!)
        .ToDictionary(e => e.Symbol);

    public static Evaluator GetEvaluator(string symbol)
    {
        return Evaluators[symbol];
    }
}