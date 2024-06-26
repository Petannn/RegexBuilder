﻿namespace RegexBuilder.Extensions;

public static class AnchorsExtensions
{
    /// <summary>
    /// By default, the match must start at the beginning of the string; in multiline mode, it must start at the beginning of the line.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static IRegexBuilder LineStart(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.StartLine);
    }

    /// <summary>
    /// The match must occur at the start of the string.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static IRegexBuilder StringStart(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.StartString);
    }

   
    /// <summary>
    /// By default, the match must occur at the end of the string or before \n at the end of the string; in multiline mode, it must occur before the end of the line or before \n at the end of the line.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static IRegexBuilder LineEnd(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.EndLine);
    }

    /// <summary>
    /// The match must occur at the end of the string.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static IRegexBuilder StringEnd(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.EndString);
    }

    /// <summary>
    /// The match must occur at the end of the string or before \n at the end of the string.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static IRegexBuilder StringEndOrLastLineEnd(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.EndStringOrEndLine);
    }

    /// <summary>
    /// The match must occur at the point where the previous match ended, or if there was no previous match, at the position in the string where matching started.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRegexBuilder PreviousMatchEnd(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.PreviousMatchEnd);
    }

    /// <summary>
    /// The match must occur on a boundary between a \w (alphanumeric) and a \W (nonalphanumeric) character.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRegexBuilder WordBoundary(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.WordBoundary);
    }

    /// <summary>
    /// The match must not occur on a \b boundary.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRegexBuilder NonWordBoundary(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(Anchors.NonWordBoundary);
    }
}