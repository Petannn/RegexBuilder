using System.Globalization;

namespace RegexBuilder.Extensions;

public static class SubstitutionsExtensions
{
    public static IRegexBuilder Placeholder(this IRegexBuilder builder, int placeholderNumber)
    {
        builder.AddRegexPattern(Substitutions.Placeholder);
        builder.AddRegexPattern(placeholderNumber.ToString());
        return builder;
    }

    public static IRegexBuilder Placeholder(this IRegexBuilder builder, string groupName)
    {
        builder.AddRegexPattern(Substitutions.Placeholder);
        builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, "{{0}}", groupName));
        return builder;
    }

    public static IRegexBuilder PlaceholderAsDollar(this IRegexBuilder builder)
    {
        builder.AddRegexPattern(Substitutions.Placeholder);
        builder.AddRegexPattern(Substitutions.Placeholder);
        return builder;
    }

    public static IRegexBuilder CopyWholeMatch(this IRegexBuilder builder)
    {
        builder.AddRegexPattern(Substitutions.Placeholder);
        builder.AddRegexPattern("&");
        return builder;
    }

    public static IRegexBuilder CopyWholeTextBeforeMatch(this IRegexBuilder builder)
    {
        builder.AddRegexPattern(Substitutions.Placeholder);
        builder.AddRegexPattern("`");
        return builder;
    }
    public static IRegexBuilder CopyWholeTextAfterMatch(this IRegexBuilder builder)
    {
        builder.AddRegexPattern(Substitutions.Placeholder);
        builder.AddRegexPattern("'");
        return builder;
    }

    public static IRegexBuilder CopyLastCapturedMatch(this IRegexBuilder builder)
    {
        builder.AddRegexPattern(Substitutions.Placeholder);
        builder.AddRegexPattern("+");
        return builder;
    }

    public static IRegexBuilder CopyInputText(this IRegexBuilder builder)
    {
        builder.AddRegexPattern(Substitutions.Placeholder);
        builder.AddRegexPattern("_");
        return builder;
    }
}