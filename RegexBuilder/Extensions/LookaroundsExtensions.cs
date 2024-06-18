namespace RegexBuilder.Extensions;

public static class LookaroundsExtensions
{
    public static IRegexBuilder Before(this IRegexBuilder builder, Action<IRegexBuilder> expression)
    {
        builder.Append("(?=");
        expression(builder);
        builder.Append(")");
        return builder;
    }

    public static IRegexBuilder Before(this IRegexBuilder builder, string expression)
    {
        builder.Append("(?=");
        builder.Append(expression);
        builder.Append(")");
        return builder;
    }

    public static IRegexBuilder NotBefore(this IRegexBuilder builder, Action<IRegexBuilder> expression)
    {
        builder.Append("(?!");
        expression(builder);
        builder.Append(")");
        return builder;
    }

    public static IRegexBuilder NotBefore(this IRegexBuilder builder, string expression)
    {
        builder.Append("(?!");
        builder.Append(expression);
        builder.Append(")");
        return builder;
    }

    public static IRegexBuilder Behind(this IRegexBuilder builder, Action<IRegexBuilder> expression)
    {
        builder.Append("(?<=");
        expression(builder);
        builder.Append(")");
        return builder;
    }

    public static IRegexBuilder Behind(this IRegexBuilder builder, string expression)
    {
        builder.Append("(?<=");
        builder.Append(expression);
        builder.Append(")");
        return builder;
    }

    public static IRegexBuilder NotBehind(this IRegexBuilder builder, Action<IRegexBuilder> expression)
    {
        builder.Append("(?<!");
        expression(builder);
        builder.Append(")");
        return builder;
    }

    public static IRegexBuilder NotBehind(this IRegexBuilder builder, string expression)
    {
        builder.Append("(?<!");
        builder.Append(expression);
        builder.Append(")");
        return builder;
    }
}