namespace RegexBuilder.Extensions;

public static class BackReferenceExtensions
{
    /// <summary>
    /// Named backreference. Matches the value of a named expression.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static IRegexBuilder Ref(this IRegexBuilder builder, string name)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("\\k<");
        builder.AddRegexPattern(name);
        builder.AddRegexPattern(">");
        return builder;
    }

    /// <summary>
    /// Backreference. Matches the value of a numbered subexpression.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="groupOrder"></param>
    /// <returns></returns>
    public static IRegexBuilder Ref(this IRegexBuilder builder, int groupOrder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("\\");
        builder.AddRegexPattern(groupOrder.ToString());
        return builder;
    }
}