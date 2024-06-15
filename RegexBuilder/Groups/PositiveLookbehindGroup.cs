using System.Globalization;

namespace RegexBuilder.Groups;

public class PositiveLookbehindGroup : Group
{
    public override string ToRegexPattern()
    {
        return string.Format(CultureInfo.InvariantCulture, "(?<={0})", base.ToRegexPattern());
    }
}