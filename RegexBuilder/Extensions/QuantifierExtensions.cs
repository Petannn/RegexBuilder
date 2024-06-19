using System.Globalization;

namespace RegexBuilder.Extensions;

public static class QuantifierExtensions
{
    /// <summary>
    /// Matches the previous element zero or more times.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRegexBuilder ZeroOrMoreTimes(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern("*");
    }

    /// <summary>
    /// Matches the previous element one or more times.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRegexBuilder OneOrMoreTimes(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern("+");
    }

    /// <summary>
    /// Matches the previous element zero or one time.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRegexBuilder ZeroOrOneTime(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern("?");
    }

    /// <summary>
    /// Matches the previous element exactly n times.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="times"></param>
    /// <returns></returns>
    public static IRegexBuilder ExactTimes(this IRegexBuilder builder, int times)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, "{{{0}}}", times));
    }

    /// <summary>
    /// Matches the previous element at least n times.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="minimum"></param>
    /// <returns></returns>
    public static IRegexBuilder AtLeastTimes(this IRegexBuilder builder, int minimum)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, "{{{0},}}", minimum));
    }

    /// <summary>
    /// Matches the previous element at least n times, but no more than m times.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="minimum"></param>
    /// <param name="maximum"></param>
    /// <returns></returns>
    public static IRegexBuilder BetweenTimes(this IRegexBuilder builder, uint minimum, int maximum)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, "{{{0},{1}}}", minimum, maximum));
    }

    /// <summary>
    /// Make the previous quantifier lazy 
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRegexBuilder AsFewAsPossibleTimes(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern("?");
    }
}