using System.Globalization;

namespace RegexBuilder.Groups;

public class MatchedGroup : Group
{
    public override string ToRegexPattern()
    {
        return string.Format(CultureInfo.InvariantCulture, "({0})", base.ToRegexPattern());
    }
}