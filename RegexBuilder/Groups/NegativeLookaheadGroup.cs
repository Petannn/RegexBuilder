using System.Globalization;

namespace RegexBuilder.Groups;

public class NegativeLookaheadGroup : Group
{
    public override string ToRegexPattern()
    {
        return string.Format(CultureInfo.InvariantCulture, "(?!{0})", base.ToRegexPattern());
    }
}