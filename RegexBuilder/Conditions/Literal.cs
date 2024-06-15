using System.Globalization;

namespace RegexBuilder.Conditions;

public class Literal : ICondition
{
    private readonly string _pattern;

    public Literal(string text)
    {
        _pattern = text;
    }

    public Literal(char ch)
    {
        _pattern += ch;
    }

    private readonly string _result;

    public Literal(char from, char to, bool exclude = false)
    {
        string rangePattern = string.Format(CultureInfo.InvariantCulture, "\\u{0:X4}-\\u{1:X4}", (int)from, (int)to);
        _pattern = string.Format(CultureInfo.InvariantCulture, exclude ? "[^{0}]" : "[{0}]", rangePattern);
    }

    public Literal(string chars, bool exclude = false)
    {
        _pattern = string.Format(CultureInfo.InvariantCulture, exclude ? "[^{0}]" : "[{0}]", chars);
    }

    public string ToRegexPattern()
    {
        return _pattern.Replace(".", @"\.");
    }
}