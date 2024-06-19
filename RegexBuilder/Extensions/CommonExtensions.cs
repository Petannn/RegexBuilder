using System.Globalization;
using System.Text.RegularExpressions;

namespace RegexBuilder.Extensions;

public static class CommonExtensions
{
    internal static IRegexBuilder Set(this IRegexBuilder builder, string range)
    {
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, "[{0}]", range));
    }

    internal static IRegexBuilder NegSet(this IRegexBuilder builder, string range)
    {
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, "[^{0}]", range));
    }

    internal static string Escape(string text)
    {
        string[] escapingChars = ["\\","^",   "$",   ".",   "|",   "?",   "*",   "+",   "(",   ")",   "[",   "]",   "{",   "}"];
        return escapingChars.Aggregate(text, (current, t) => current.Replace(t, "\\" + t));
    }

    /// <summary>
    /// Add characters to be searched
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static IRegexBuilder Add(this IRegexBuilder builder, string value)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Escape(value));
    }

    public static IRegexBuilder Word(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.WordChar().OneOrMoreTimes();
    }

    public static IRegexBuilder IntValue(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.Digit().OneOrMoreTimes();
    }

    public static IRegexBuilder FloatValue(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.Digit().OneOrMoreTimes().Dot().ZeroOrOneTime().Digit().ZeroOrMoreTimes();
    }

    public static Regex Build(this IRegexBuilder builder, RegexOptions options = RegexOptions.None)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return new Regex(builder.ToString(), options);
    }
}