using System.Globalization;

namespace RegexBuilder.Extensions;

public static class CharacterClassesExtensions
{
    /// <summary>
    /// Character range: Matches any single character in the range from first to last.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public static IRegexBuilder CharRange(this IRegexBuilder builder, char from, char to)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.Set(string.Format(CultureInfo.InvariantCulture, "{0}-{1}", from, to));
    }

    /// <summary>
    /// Negation: Matches any single character that is not in character_group. By default, characters in character_group are case-sensitive.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public static IRegexBuilder NonCharRange(this IRegexBuilder builder, char from, char to)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.NegSet(string.Format(CultureInfo.InvariantCulture, "{0}-{1}", from, to));
    }

    /// <summary>
    /// Matches any single character in charSet. By default, the match is case-sensitive.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="charSet"></param>
    /// <returns></returns>
    public static IRegexBuilder CharSet(this IRegexBuilder builder, string charSet)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.Set(string.Format(CultureInfo.InvariantCulture, "{0}", charSet));
    }

    /// <summary>
    /// Matches any single character in charSet. By default, the match is case-sensitive.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="charSet"></param>
    /// <returns></returns>
    public static IRegexBuilder CharSet(this IRegexBuilder builder, params char[] charSet)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.Set(string.Format(CultureInfo.InvariantCulture, "{0}", charSet));
    }

    /// <summary>
    /// Matches any single character that is not in charSet. By default, the match is case-sensitive.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="charSet"></param>
    /// <returns></returns>
    public static IRegexBuilder NonCharSet(this IRegexBuilder builder, string charSet)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.NegSet(string.Format(CultureInfo.InvariantCulture, "{0}", charSet));
    }

    /// <summary>
    /// Matches any single character that is not in charSet. By default, the match is case-sensitive.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="charSet"></param>
    /// <returns></returns>
    public static IRegexBuilder NonCharSet(this IRegexBuilder builder, params char[] charSet)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.NegSet(string.Format(CultureInfo.InvariantCulture, "{0}", charSet));
    }

    /// <summary>
    /// Matches any single character in the Unicode general category or named block specified by name.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="category"></param>
    /// <returns></returns>
    public static IRegexBuilder CharCategory(this IRegexBuilder builder, string category)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, "\\p{{0}}", category));
    }

    /// <summary>
    /// Matches any single character that is not in the Unicode general category or named block specified by name.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="category"></param>
    /// <returns></returns>
    public static IRegexBuilder NonCharCategory(this IRegexBuilder builder, string category)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, "\\P{{0}}", category));
    }

    /// <summary>
    /// Matches any word character.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRegexBuilder WordChar(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(MetaChars.WordCharacter);
    }

    /// <summary>
    /// Matches any non-word character.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRegexBuilder NonWordChar(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(MetaChars.NonWordCharacter);
    }

    /// <summary>
    /// Matches any white-space character.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRegexBuilder WhiteSpace(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(MetaChars.WhiteSpace);
    }

    /// <summary>
    /// Matches any non-white-space character.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRegexBuilder NonWhiteSpace(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(MetaChars.NonWhiteSpace);
    }

    /// <summary>
    /// Matches any decimal digit.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRegexBuilder Digit(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(MetaChars.AnyDigit);
    }

    /// <summary>
    /// Matches any character other than a decimal digit.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRegexBuilder NonDigit(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(MetaChars.NonDigit);
    }

    /// <summary>
    /// Matches '.'
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRegexBuilder Dot(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern("\\.");
    }

    /// <summary>
    /// Matches any character
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRegexBuilder AnyChar(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(MetaChars.Any);
    }
}