namespace RegexBuilder.Conditions;

public class Value : ICondition
{
    private readonly string _pattern = @"\d";

    public Value() { }

    public Value(int value)
    {
        _pattern = value.ToString();
    }

    public string ToRegexPattern()
    {
        return _pattern;
    }
}