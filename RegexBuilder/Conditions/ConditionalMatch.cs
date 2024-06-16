using System.Globalization;

namespace RegexBuilder.Conditions;

public class ConditionalMatch : ICondition
{
    private readonly string _pattern;

    public ConditionalMatch(ICondition condition, ICondition trueCondition, ICondition falseCondition)
    {
        _pattern = string.Format(CultureInfo.InvariantCulture, "(?({0}){1}|{2})", condition.ToRegexPattern(), trueCondition.ToRegexPattern(), falseCondition.ToRegexPattern());
    }

    public ConditionalMatch(ICondition condition, ICondition trueCondition)
    {
        _pattern = string.Format(CultureInfo.InvariantCulture, "(?({0}){1})", condition.ToRegexPattern(), trueCondition.ToRegexPattern());
    }

    public string ToRegexPattern()
    {
        return _pattern;
    }
}