namespace RegexBuilder.Extensions;

public static class AlternationExtensions
{
    public static IRegexBuilder Or(this IRegexBuilder builder)
    {
        return builder.AddRegexPattern("|");
    }

    public static IRegexBuilder Condition(this IRegexBuilder builder, Action<IRegexBuilder> expression, Action<IRegexBuilder> yes)
    {
        builder.AddRegexPattern("(?(");
        expression(builder);
        builder.AddRegexPattern(")");
        yes(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    public static IRegexBuilder Condition(this IRegexBuilder builder, Action<IRegexBuilder> expression, string yes)
    {
        builder.AddRegexPattern("(?(");
        expression(builder);
        builder.AddRegexPattern(")");
        builder.AddRegexPattern(yes);
        builder.AddRegexPattern(")");
        return builder;
    }

    public static IRegexBuilder Condition(this IRegexBuilder builder, string expression, Action<IRegexBuilder> yes)
    {
        builder.AddRegexPattern("(?(");
        builder.AddRegexPattern(expression);
        builder.AddRegexPattern(")");
        yes(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    public static IRegexBuilder Condition(this IRegexBuilder builder, string expression, string yes)
    {
        builder.AddRegexPattern("(?(");
        builder.AddRegexPattern(expression);
        builder.AddRegexPattern(")");
        builder.AddRegexPattern(yes);
        builder.AddRegexPattern(")");
        return builder;
    }

    public static IRegexBuilder Condition(this IRegexBuilder builder, Action<IRegexBuilder> expression, Action<IRegexBuilder> yes, Action<IRegexBuilder> no)
    {
        builder.AddRegexPattern("(?(");
        expression(builder);
        builder.AddRegexPattern(")");
        yes(builder);
        builder.Or();
        no(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    public static IRegexBuilder Condition(this IRegexBuilder builder, Action<IRegexBuilder> expression, Action<IRegexBuilder> yes, string no)
    {
        builder.AddRegexPattern("(?(");
        expression(builder);
        builder.AddRegexPattern(")");
        yes(builder);
        builder.Or();
        builder.AddRegexPattern(no);
        builder.AddRegexPattern(")");
        return builder;
    }

    public static IRegexBuilder Condition(this IRegexBuilder builder, Action<IRegexBuilder> expression, string yes, Action<IRegexBuilder> no)
    {
        builder.AddRegexPattern("(?(");
        expression(builder);
        builder.AddRegexPattern(")");
        builder.AddRegexPattern(yes);
        builder.Or();
        no(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    public static IRegexBuilder Condition(this IRegexBuilder builder, Action<IRegexBuilder> expression, string yes, string no)
    {
        builder.AddRegexPattern("(?(");
        expression(builder);
        builder.AddRegexPattern(")");
        builder.AddRegexPattern(yes);
        builder.Or();
        builder.AddRegexPattern(no);
        builder.AddRegexPattern(")");
        return builder;
    }

    public static IRegexBuilder Condition(this IRegexBuilder builder, string expression, Action<IRegexBuilder> yes, Action<IRegexBuilder> no)
    {
        builder.AddRegexPattern("(?(");
        builder.AddRegexPattern(expression);
        builder.AddRegexPattern(")");
        yes(builder);
        builder.Or();
        no(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    public static IRegexBuilder Condition(this IRegexBuilder builder, string expression, Action<IRegexBuilder> yes, string no)
    {
        builder.AddRegexPattern("(?(");
        builder.AddRegexPattern(expression);
        builder.AddRegexPattern(")");
        yes(builder);
        builder.Or();
        builder.AddRegexPattern(no);
        builder.AddRegexPattern(")");
        return builder;
    }

    public static IRegexBuilder Condition(this IRegexBuilder builder, string expression, string yes, Action<IRegexBuilder> no)
    {
        builder.AddRegexPattern("(?(");
        builder.AddRegexPattern(expression);
        builder.AddRegexPattern(")");
        builder.AddRegexPattern(yes);
        builder.Or();
        no(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    public static IRegexBuilder Condition(this IRegexBuilder builder, string expression, string yes, string no)
    {
        builder.AddRegexPattern("(?(");
        builder.AddRegexPattern(expression);
        builder.AddRegexPattern(")");
        builder.AddRegexPattern(yes);
        builder.Or();
        builder.AddRegexPattern(no);
        builder.AddRegexPattern(")");
        return builder;
    }
}