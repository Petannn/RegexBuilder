using System.Globalization;

namespace RegexBuilder.Extensions;

public static class QuantifierExtensions
{
    public static IRegexBuilder ZeroOrMoreTimes(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern("*");
    }

    public static IRegexBuilder OneOrMoreTimes(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern("+");
    }

    public static IRegexBuilder ZeroOrOneTime(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern("?");
    }

    public static IRegexBuilder ExactTimes(this IRegexBuilder builder, int times)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, "{{{0}}}", times));
    }

    public static IRegexBuilder AtLeastTimes(this IRegexBuilder builder, int minimum)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, "{{{0},}}", minimum));
    }

    public static IRegexBuilder BetweenTimes(this IRegexBuilder builder, uint minimum, int? maximum)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, "{{{0},{1}}}", minimum, maximum));
    }

    public static IRegexBuilder AsFewAsPossibleTimes(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern("?");
    }
}