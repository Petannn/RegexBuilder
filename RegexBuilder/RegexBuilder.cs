using System.Text;

namespace RegexBuilder;

public interface IOptionBuilder
{

    IOptionBuilder AddOption(string pattern);
}

public interface IRegexBuilder : IOptionBuilder
{
    IRegexBuilder Append(string text);
    string ToString();
}

public class RegexBuilder : IRegexBuilder
{
    private readonly StringBuilder _builder = new();

    public IRegexBuilder AddRegexPattern(string pattern)
    {
        _builder.Append(pattern);
        return this;
    }

    public IOptionBuilder AddOption(string pattern)
    {
        AddRegexPattern(pattern);
        return this;
    }

    public override string ToString()
    {
        return _builder.ToString();
    }
}