using System.Globalization;

namespace RegexBuilder.Groups;

public class AtomicGroup : Group
{
    public override IGroup AddCondition(string condition)
    {
        if (_patterns.Count != 0)
        {
            _patterns.Add(new Pattern("|"));
        }

        _patterns.Add(new Pattern(condition));
        return this;
    }

    public override IGroup AddCondition(string condition, IQuantifier quantifier)
    {
        if (_patterns.Count != 0)
        {
            _patterns.Add(new Pattern("|"));
        }

        _patterns.Add(new Pattern(condition, quantifier));
        return this;
    }

    public override string ToRegexPattern()
    {
        return string.Format(CultureInfo.InvariantCulture, "(?>{0})", base.ToRegexPattern());
    }
}