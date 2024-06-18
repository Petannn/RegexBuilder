using System.Globalization;

namespace RegexBuilder.Extensions;

public static class CharacterClassesExtensions
{
    public static IRegexBuilder CharRange(this IRegexBuilder builder, char from, char to)
    {
        return builder.Set(string.Format(CultureInfo.InvariantCulture, "{0}-{1}", from, to));
    }

    public static IRegexBuilder NonCharRange(this IRegexBuilder builder, char from, char to)
    {
        return builder.NegSet(string.Format(CultureInfo.InvariantCulture, "{0}-{1}", from, to));
    }

    public static IRegexBuilder CharSet(this IRegexBuilder builder, string charSet)
    {
        return builder.Set(string.Format(CultureInfo.InvariantCulture, "{0}", charSet));
    }

    public static IRegexBuilder CharSet(this IRegexBuilder builder, params char[] charSet)
    {
        return builder.Set(string.Format(CultureInfo.InvariantCulture, "{0}", charSet));
    }

    public static IRegexBuilder NonCharSet(this IRegexBuilder builder, string charSet)
    {
        return builder.NegSet(string.Format(CultureInfo.InvariantCulture, "{0}", charSet));
    }

    public static IRegexBuilder NonCharSet(this IRegexBuilder builder, params char[] charSet)
    {
        return builder.NegSet(string.Format(CultureInfo.InvariantCulture, "{0}", charSet));
    }

    public static IRegexBuilder CharCategory(this IRegexBuilder builder, string category)
    {
        return builder.Append(string.Format(CultureInfo.InvariantCulture, "\\p{{0}}", category));
    }

    public static IRegexBuilder NonCharCategory(this IRegexBuilder builder, string category)
    {
        return builder.Append(string.Format(CultureInfo.InvariantCulture, "\\P{{0}}", category));
    }

    public static IRegexBuilder WordChar(this IRegexBuilder builder)
    {
        return builder.Append(MetaChars.WordCharacter);
    }

    public static IRegexBuilder NonWordChar(this IRegexBuilder builder)
    {
        return builder.Append(MetaChars.NonWordCharacter);
    }

    public static IRegexBuilder WhiteSpace(this IRegexBuilder builder)
    {
        return builder.Append(MetaChars.WhiteSpace);
    }

    public static IRegexBuilder NonWhiteSpace(this IRegexBuilder builder)
    {
        return builder.Append(MetaChars.NonWhiteSpace);
    }

    public static IRegexBuilder Digit(this IRegexBuilder builder)
    {
        return builder.Append(MetaChars.AnyDigit);
    }

    public static IRegexBuilder NonDigit(this IRegexBuilder builder)
    {
        return builder.Append(MetaChars.NonDigit);
    }

    public static IRegexBuilder Dot(this IRegexBuilder builder)
    {
        return builder.Append("\\.");
    }
}