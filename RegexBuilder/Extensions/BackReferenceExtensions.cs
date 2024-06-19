namespace RegexBuilder.Extensions;

public static class BackReferenceExtensions
{
    public static IRegexBuilder Ref(this IRegexBuilder builder, string name)
    {
        builder.AddRegexPattern("\\k<");
        builder.AddRegexPattern(name);
        builder.AddRegexPattern(">");
        return builder;
    }

    public static IRegexBuilder Ref(this IRegexBuilder builder, int groupOrder)
    {
        builder.AddRegexPattern("\\");
        builder.AddRegexPattern(groupOrder.ToString());
        return builder;
    }
}