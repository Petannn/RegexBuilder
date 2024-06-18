namespace RegexBuilder.Extensions;

public static class AnchorsExtensions
{
    public static IRegexBuilder LineMustStartWith(this IRegexBuilder builder, string value)
    {
        return builder.Add(Anchors.StartLine).Add(value);
    }

    public static IRegexBuilder MustStartWith(this IRegexBuilder builder, string value)
    {
        return builder.Add(Anchors.StartString).Add(value);
    }

    public static IRegexBuilder LineMustEndWith(this IRegexBuilder builder, string value)
    {
        return builder.Add(Anchors.EndLine).Add(value);
    }

    public static IRegexBuilder MustEndWith(this IRegexBuilder builder, string value)
    {
        return builder.Add(Anchors.EndString).Add(value);
    }
    public static IRegexBuilder MustEndOrLasLineEndWith(this IRegexBuilder builder, string value)
    {
        return builder.Add(Anchors.EndStringOrEndLine).Add(value);
    }

    public static IRegexBuilder PreviousMatchEnd(this IRegexBuilder builder)
    {
        return builder.Add(Anchors.PreviousMatchEnd);
    }

    public static IRegexBuilder WordBoundary(this IRegexBuilder builder)
    {
        return builder.Add(Anchors.WordBoundary);
    }

    public static IRegexBuilder NonWordBoundary(this IRegexBuilder builder)
    {
        return builder.Add(Anchors.NonWordBoundary);
    }
}