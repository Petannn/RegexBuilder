using System.Globalization;

namespace RegexBuilder.Conditions;

public class AnyWorld : ICondition
{
    private string _pattern;

    public AnyWorld(string type)
    {
        _pattern = string.Format(CultureInfo.InvariantCulture, "\\b{0}+\\b", type);
    }

    public string ToRegexPattern()
    {
        return _pattern;
    }
}