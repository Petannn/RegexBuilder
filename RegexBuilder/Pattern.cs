namespace RegexBuilder;

public class Pattern
{
    private readonly string _condition;
    private readonly IQuantifier? _quantifier;

    public Pattern(string condition, IQuantifier? quantifier = null)
    {
        _condition = condition;
        _quantifier = quantifier;
    }

    public string Build()
    {
        return _quantifier == null ? _condition : _quantifier.ToRegexPattern(_condition);
    }
}