using System.Text;

namespace RegexBuilder;

public interface IOptionBuilder
{
    /// <summary>
    /// Adds a new option group to the builder based on the provided text. This method is intended for advanced usage and should only be utilized if explicitly recommended by the API documentation.
    /// </summary>
    /// <param name="pattern">The option group text, specifying the settings for regex options such as 'i' (case-insensitive), 'm' (multi-line), 'n' (explicit capture), 's' (dot matches all), and 'x' (ignore pattern whitespace). The text should correctly encode these options as needed for the regex processing.</param>
    /// <returns>
    /// Returns an instance of <see cref="IOptionBuilder"/> with the added option group, enabling further configuration or modification of regex behavior.
    /// </returns>
    /// <remarks>
    /// This method allows for the configuration of specific regex behaviors that are critical for certain patterns but may introduce complexities or unexpected results if used without a proper understanding of the regex option effects. It is recommended that this method be used only in scenarios where such specific behavior modifications are necessary and have been explicitly advised in the API's usage guidelines.
    /// </remarks>
    IOptionBuilder AddOption(string pattern);
}

public interface IRegexBuilder : IOptionBuilder
{
    /// <summary>
    /// Adds a new regular expression pattern to the builder based on the provided, pre-escaped text.
    /// </summary>
    /// <param name="pattern">The regular expression pattern to be added. This string should already be properly escaped to conform to the specific requirements and syntax of regular expressions. It is assumed that the pattern is ready to be compiled or utilized directly without further modification.</param>
    /// <returns>
    /// Returns an instance of <see cref="IRegexBuilder"/> with the added regular expression pattern, enabling fluent construction.
    /// </returns>
    IRegexBuilder AddRegexPattern(string pattern);
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