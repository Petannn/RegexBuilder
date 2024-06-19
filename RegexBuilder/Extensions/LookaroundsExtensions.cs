namespace RegexBuilder.Extensions;

public static class LookaroundsExtensions
{
    /// <summary>
    /// Positive Lookahead. Asserts that what immediately follows the current position in the string is "expression"
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IRegexBuilder Before(this IRegexBuilder builder, Action<IRegexBuilder> expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?=");
        expression(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Positive Lookahead. Asserts that what immediately follows the current position in the string is "expression"
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IRegexBuilder Before(this IRegexBuilder builder, string expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?=");
        builder.AddRegexPattern(expression);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Negative Lookahead. Asserts that what immediately follows the current position in the string is not "expression"
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IRegexBuilder NotBefore(this IRegexBuilder builder, Action<IRegexBuilder> expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?!");
        expression(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Negative Lookahead. Asserts that what immediately follows the current position in the string is not "expression"
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IRegexBuilder NotBefore(this IRegexBuilder builder, string expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?!");
        builder.AddRegexPattern(expression);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Positive Lookbehind. Asserts that what immediately precedes the current position in the string is "expression"
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IRegexBuilder Behind(this IRegexBuilder builder, Action<IRegexBuilder> expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?<=");
        expression(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Positive Lookbehind. Asserts that what immediately precedes the current position in the string is "expression"
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IRegexBuilder Behind(this IRegexBuilder builder, string expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?<=");
        builder.AddRegexPattern(expression);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Negative Lookbehind. Asserts that what immediately precedes the current position in the string is not "expression"
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IRegexBuilder NotBehind(this IRegexBuilder builder, Action<IRegexBuilder> expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?<!");
        expression(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Negative Lookbehind. Asserts that what immediately precedes the current position in the string is not "expression"
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IRegexBuilder NotBehind(this IRegexBuilder builder, string expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?<!");
        builder.AddRegexPattern(expression);
        builder.AddRegexPattern(")");
        return builder;
    }
}