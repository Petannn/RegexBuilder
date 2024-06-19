namespace RegexBuilder.Extensions;

public static class OptionsExtensions
{
    /// <summary>
    /// Use case-insensitive matching.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IOptionBuilder IgnoreCase(this IOptionBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddOption("i");
    }

    /// <summary>
    /// Use multiline mode. ^ and $ match the beginning and end of a line, instead of the beginning and end of a string.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IOptionBuilder MultiLineMode(this IOptionBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddOption("m");
    }

    /// <summary>
    /// Use single-line mode.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IOptionBuilder SingleLineMode(this IOptionBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddOption("s");
    }

    /// <summary>
    /// Do not capture unnamed groups.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IOptionBuilder DoNotCaptureUnnamedGroups(this IOptionBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddOption("n");
    }

    /// <summary>
    /// Ignore unescaped white space in the regular expression pattern.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IOptionBuilder IgnoreUnescapedWhitespaceInPattern(this IOptionBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddOption("x");
    }
}