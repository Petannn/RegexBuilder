using System.Globalization;

namespace RegexBuilder.Groups;

public class BalancingGroup : Group
{
    private readonly string? _name1;
    private readonly string? _name2;

    public BalancingGroup(string name1, string name2)
    {
        _name1 = name1;
        _name2 = name2;
    }

    public override string ToRegexPattern()
    {
        return string.Format(CultureInfo.InvariantCulture, "(?<{0}-{1}>{2})", _name1, _name2, base.ToRegexPattern());
    }
}