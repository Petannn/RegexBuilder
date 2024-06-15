using System.Globalization;

namespace RegexBuilder.Conditions;

public class Comment : ICondition
{
    private readonly string _pattern;

    public Comment(string pattern)
    {
        _pattern = pattern;
    }

    public string ToRegexPattern()
    {
        return string.Format(CultureInfo.InvariantCulture, "(?#{0})", _pattern);
    }
}