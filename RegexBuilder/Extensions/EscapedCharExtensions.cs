﻿using System.Globalization;

namespace RegexBuilder.Extensions;

public static class EscapedCharExtensions
{
    public static IRegexBuilder Bell(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(EscapedChars.Bell);
    }

    public static IRegexBuilder Backspace(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(EscapedChars.Backspace);
    }

    public static IRegexBuilder Tab(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(EscapedChars.Tab);
    }

    public static IRegexBuilder CarriageReturn(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(EscapedChars.CarriageReturn);
    }

    public static IRegexBuilder VerticalTab(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(EscapedChars.VerticalTab);
    }

    public static IRegexBuilder FormFeed(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(EscapedChars.FormFeed);
    }

    public static IRegexBuilder NewLine(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(EscapedChars.NewLine);
    }

    public static IRegexBuilder Escape(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(EscapedChars.Escape);
    }

    public static IRegexBuilder OctalRepresentation(this IRegexBuilder builder, char code)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        string octal = Convert.ToString(code, 8);
        octal = octal.PadLeft(3, '0');
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, EscapedChars.OctalRepresentation + "{0}", octal));
    }

    public static IRegexBuilder HexadecimalRepresentation(this IRegexBuilder builder, char code)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        string hex = Convert.ToString(code, 16);
        hex = hex.PadLeft(2, '0');
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, EscapedChars.HexadecimalRepresentation + "{0}", hex));
    }

    public static IRegexBuilder ASCIIControlChar(this IRegexBuilder builder, char code)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        string hex = Convert.ToString(code, 16);
        hex = hex.PadLeft(4, '0');
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, EscapedChars.ASCIIControlChar + "{0}", hex));
    }

    public static IRegexBuilder Unicode(this IRegexBuilder builder, int code)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        if (code < 0 || code > 65535) throw new ArgumentOutOfRangeException("code");
        string hex = Convert.ToString(code, 16);
        hex = hex.PadLeft(4, '0');
        return builder.AddRegexPattern(string.Format(CultureInfo.InvariantCulture, EscapedChars.Unicode + "{0}", hex));
    }
}