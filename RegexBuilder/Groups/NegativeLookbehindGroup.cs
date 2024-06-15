using System.Globalization;

namespace RegexBuilder.Groups;

public class NegativeLookbehindGroup : Group
{
    public override string ToRegexPattern()
    {
        return string.Format(CultureInfo.InvariantCulture, "(?<!{0})", base.ToRegexPattern());
    }
}