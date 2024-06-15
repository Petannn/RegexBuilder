namespace RegexBuilder;

public interface IQuantifier
{
    string ToRegexPattern(string condition);
}