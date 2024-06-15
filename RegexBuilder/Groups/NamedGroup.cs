using System.Globalization;

namespace RegexBuilder.Groups;

public class NamedGroup : Group
{
    private readonly string? _name;

    public NamedGroup(string name)
    {
        _name = name;
    }
    
    public override string ToRegexPattern()
    {
        return string.Format(CultureInfo.InvariantCulture, "(?<{0}>{1})", _name, base.ToRegexPattern());
    }
}