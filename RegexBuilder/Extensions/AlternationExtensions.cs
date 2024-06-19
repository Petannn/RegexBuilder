namespace RegexBuilder.Extensions;

public static class AlternationExtensions
{
    public static IRegexBuilder Or(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern("|");
    }

    /// <summary>
    /// Matches yes if the regular expression pattern designated by expression matches; otherwise, matches the optional no part. expression is interpreted as a zero-width assertion.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <param name="yes"></param>
    /// <returns></returns>
    public static IRegexBuilder Condition(this IRegexBuilder builder, Action<IRegexBuilder> expression, Action<IRegexBuilder> yes)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?(");
        expression(builder);
        builder.AddRegexPattern(")");
        yes(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Matches yes if the regular expression pattern designated by expression matches; otherwise, matches the optional no part. expression is interpreted as a zero-width assertion.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <param name="yes"></param>
    /// <returns></returns>
    public static IRegexBuilder Condition(this IRegexBuilder builder, Action<IRegexBuilder> expression, string yes)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?(");
        expression(builder);
        builder.AddRegexPattern(")");
        builder.AddRegexPattern(yes);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Matches yes if the regular expression pattern designated by expression matches; otherwise, matches the optional no part. expression is interpreted as a zero-width assertion.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <param name="yes"></param>
    /// <returns></returns>
    public static IRegexBuilder Condition(this IRegexBuilder builder, string expression, Action<IRegexBuilder> yes)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?(");
        builder.AddRegexPattern(expression);
        builder.AddRegexPattern(")");
        yes(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Matches yes if the regular expression pattern designated by expression matches; otherwise, matches the optional no part. expression is interpreted as a zero-width assertion.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <param name="yes"></param>
    /// <returns></returns>
    public static IRegexBuilder Condition(this IRegexBuilder builder, string expression, string yes)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?(");
        builder.AddRegexPattern(expression);
        builder.AddRegexPattern(")");
        builder.AddRegexPattern(yes);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Matches yes if the regular expression pattern designated by expression matches; otherwise, matches the optional no part. expression is interpreted as a zero-width assertion.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <param name="yes"></param>
    /// <param name="no"></param>
    /// <returns></returns>
    public static IRegexBuilder Condition(this IRegexBuilder builder, Action<IRegexBuilder> expression, Action<IRegexBuilder> yes, Action<IRegexBuilder> no)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?(");
        expression(builder);
        builder.AddRegexPattern(")");
        yes(builder);
        builder.Or();
        no(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Matches yes if the regular expression pattern designated by expression matches; otherwise, matches the optional no part. expression is interpreted as a zero-width assertion.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <param name="yes"></param>
    /// <param name="no"></param>
    /// <returns></returns>
    public static IRegexBuilder Condition(this IRegexBuilder builder, Action<IRegexBuilder> expression, Action<IRegexBuilder> yes, string no)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?(");
        expression(builder);
        builder.AddRegexPattern(")");
        yes(builder);
        builder.Or();
        builder.AddRegexPattern(no);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Matches yes if the regular expression pattern designated by expression matches; otherwise, matches the optional no part. expression is interpreted as a zero-width assertion.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <param name="yes"></param>
    /// <param name="no"></param>
    /// <returns></returns>
    public static IRegexBuilder Condition(this IRegexBuilder builder, Action<IRegexBuilder> expression, string yes, Action<IRegexBuilder> no)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?(");
        expression(builder);
        builder.AddRegexPattern(")");
        builder.AddRegexPattern(yes);
        builder.Or();
        no(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Matches yes if the regular expression pattern designated by expression matches; otherwise, matches the optional no part. expression is interpreted as a zero-width assertion.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <param name="yes"></param>
    /// <param name="no"></param>
    /// <returns></returns>
    public static IRegexBuilder Condition(this IRegexBuilder builder, Action<IRegexBuilder> expression, string yes, string no)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?(");
        expression(builder);
        builder.AddRegexPattern(")");
        builder.AddRegexPattern(yes);
        builder.Or();
        builder.AddRegexPattern(no);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Matches yes if the regular expression pattern designated by expression matches; otherwise, matches the optional no part. expression is interpreted as a zero-width assertion.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <param name="yes"></param>
    /// <param name="no"></param>
    /// <returns></returns>
    public static IRegexBuilder Condition(this IRegexBuilder builder, string expression, Action<IRegexBuilder> yes, Action<IRegexBuilder> no)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?(");
        builder.AddRegexPattern(expression);
        builder.AddRegexPattern(")");
        yes(builder);
        builder.Or();
        no(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Matches yes if the regular expression pattern designated by expression matches; otherwise, matches the optional no part. expression is interpreted as a zero-width assertion.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <param name="yes"></param>
    /// <param name="no"></param>
    /// <returns></returns>
    public static IRegexBuilder Condition(this IRegexBuilder builder, string expression, Action<IRegexBuilder> yes, string no)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?(");
        builder.AddRegexPattern(expression);
        builder.AddRegexPattern(")");
        yes(builder);
        builder.Or();
        builder.AddRegexPattern(no);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Matches yes if the regular expression pattern designated by expression matches; otherwise, matches the optional no part. expression is interpreted as a zero-width assertion.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <param name="yes"></param>
    /// <param name="no"></param>
    /// <returns></returns>
    public static IRegexBuilder Condition(this IRegexBuilder builder, string expression, string yes, Action<IRegexBuilder> no)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?(");
        builder.AddRegexPattern(expression);
        builder.AddRegexPattern(")");
        builder.AddRegexPattern(yes);
        builder.Or();
        no(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Matches yes if the regular expression pattern designated by expression matches; otherwise, matches the optional no part. expression is interpreted as a zero-width assertion.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <param name="yes"></param>
    /// <param name="no"></param>
    /// <returns></returns>
    public static IRegexBuilder Condition(this IRegexBuilder builder, string expression, string yes, string no)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
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