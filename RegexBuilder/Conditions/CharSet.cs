using System.Globalization;

namespace RegexBuilder.Conditions;

public class CharSet : ICondition
{
    private readonly string _pattern;

    public CharSet(char from, char to, bool except = false)
    {
        _pattern = string.Format(CultureInfo.InvariantCulture, except ? "[^{0}-{1}]" : "[{0}-{1}]", from, to);
    }

    public CharSet(string set, bool except = false)
    {
        _pattern = string.Format(CultureInfo.InvariantCulture, except ? "[^{0}]" : "[{0}]", set);
    }

    public string ToRegexPattern()
    {
        return _pattern;
    }
}