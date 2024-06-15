using System.Globalization;

namespace RegexBuilder.Groups;

public class OptionsGroup : Group
{
    public override string ToRegexPattern()
    {
        return string.Format(CultureInfo.InvariantCulture, "(?imnsx-imnsx:{0})", base.ToRegexPattern());
    }
}