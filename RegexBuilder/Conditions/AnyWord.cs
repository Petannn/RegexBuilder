using System.Globalization;

namespace RegexBuilder.Conditions;

public class AnyWord : ICondition
{
    private string _pattern;

    public AnyWord(string type)
    {
        _pattern = string.Format(CultureInfo.InvariantCulture, "\\b{0}+\\b", type);
    }

    public string ToRegexPattern()
    {
        return _pattern;
    }
}