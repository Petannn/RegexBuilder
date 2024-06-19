using System.Globalization;

namespace RegexBuilder.Extensions;

public static class CharacterClassesExtensions
{
    public static IRegexBuilder CharRange(this IRegexBuilder builder, char from, char to)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.Set(string.Format(CultureInfo.InvariantCulture, "{0}-{1}", from, to));
    }

    public static IRegexBuilder NonCharRange(this IRegexBuilder builder, char from, char to)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.NegSet(string.Format(CultureInfo.InvariantCulture, "{0}-{1}", from, to));
    }

    public static IRegexBuilder CharSet(this IRegexBuilder builder, string charSet)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.Set(string.Format(CultureInfo.InvariantCulture, "{0}", charSet));
    }

    public static IRegexBuilder CharSet(this IRegexBuilder builder, params char[] charSet)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.Set(string.Format(CultureInfo.InvariantCulture, "{0}", charSet));
    }

    public static IRegexBuilder NonCharSet(this IRegexBuilder builder, string charSet)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.NegSet(string.Format(CultureInfo.InvariantCulture, "{0}", charSet));
    }

    public static IRegexBuilder NonCharSet(this IRegexBuilder builder, params char[] charSet)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.NegSet(string.Format(CultureInfo.InvariantCulture, "{0}", charSet));
    }

    public static IRegexBuilder CharCategory(this IRegexBuilder builder, string category)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, "\\p{{0}}", category));
    }

    public static IRegexBuilder NonCharCategory(this IRegexBuilder builder, string category)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, "\\P{{0}}", category));
    }

    public static IRegexBuilder WordChar(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(MetaChars.WordCharacter);
    }

    public static IRegexBuilder NonWordChar(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(MetaChars.NonWordCharacter);
    }

    public static IRegexBuilder WhiteSpace(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(MetaChars.WhiteSpace);
    }

    public static IRegexBuilder NonWhiteSpace(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(MetaChars.NonWhiteSpace);
    }

    public static IRegexBuilder Digit(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(MetaChars.AnyDigit);
    }

    public static IRegexBuilder NonDigit(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(MetaChars.NonDigit);
    }

    public static IRegexBuilder Dot(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern("\\.");
    }

    public static IRegexBuilder AnyChar(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(MetaChars.Any);
    }
}