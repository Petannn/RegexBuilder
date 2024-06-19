namespace RegexBuilder.Extensions;

public static class AnchorsExtensions
{
    public static IRegexBuilder LineMustStartWith(this IRegexBuilder builder, string value)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.StartLine).Add(value);
    }

    public static IRegexBuilder MustStartWith(this IRegexBuilder builder, string value)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.StartString).Add(value);
    }

    public static IRegexBuilder LineMustEndWith(this IRegexBuilder builder, string value)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.EndLine).Add(value);
    }

    public static IRegexBuilder MustEndWith(this IRegexBuilder builder, string value)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.EndString).Add(value);
    }
    public static IRegexBuilder MustEndOrLasLineEndWith(this IRegexBuilder builder, string value)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.EndStringOrEndLine).Add(value);
    }

    public static IRegexBuilder PreviousMatchEnd(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.PreviousMatchEnd);
    }

    public static IRegexBuilder WordBoundary(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.WordBoundary);
    }

    public static IRegexBuilder NonWordBoundary(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.NonWordBoundary);
    }
}