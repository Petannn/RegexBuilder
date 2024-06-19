namespace RegexBuilder.Extensions;

public static class BackReferenceExtensions
{
    public static IRegexBuilder Ref(this IRegexBuilder builder, string name)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("\\k<");
        builder.AddRegexPattern(name);
        builder.AddRegexPattern(">");
        return builder;
    }

    public static IRegexBuilder Ref(this IRegexBuilder builder, int groupOrder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("\\");
        builder.AddRegexPattern(groupOrder.ToString());
        return builder;
    }
}