namespace RegexBuilder.Extensions;

public static class GroupExtensions
{

    public static IRegexBuilder BeginGroup(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern("(");
    }

    public static IRegexBuilder BeginGroup(this IRegexBuilder builder, string name)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?<");
        builder.AddRegexPattern(name);
        builder.AddRegexPattern(">");
        return builder;
    }

    public static IRegexBuilder BeginNonCapturingGroup(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern("(?:");
    }

    public static IRegexBuilder BeginAtomicGroup(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern("(?>");
    }

    public static IRegexBuilder EndGroup(this IRegexBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        return builder.AddRegexPattern(")");
    }

    /// <summary>
    /// Captures the matched subexpression and assigns it a one-based ordinal number.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IRegexBuilder Group(this IRegexBuilder builder, Action<IRegexBuilder> expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.BeginGroup();
        expression(builder);
        builder.EndGroup();
        return builder;
    }

    /// <summary>
    /// Captures the matched subexpression into a named group.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="name"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IRegexBuilder Group(this IRegexBuilder builder, string name, Action<IRegexBuilder> expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.BeginGroup(name);
        expression(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Defines a balancing group definition. For more information, see the "Balancing Group Definition" section in Grouping Constructs.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="name"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IRegexBuilder BalancingGroup(this IRegexBuilder builder, string name1, string name2, Action<IRegexBuilder> expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.BeginGroup();
        builder.AddRegexPattern("?<");
        builder.AddRegexPattern(name1);
        builder.AddRegexPattern("-");
        builder.AddRegexPattern(name2);
        builder.AddRegexPattern(">");
        expression(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Defines a noncapturing group.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IRegexBuilder NonCapturingGroup(this IRegexBuilder builder, Action<IRegexBuilder> expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?:");
        expression(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Atomic group.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IRegexBuilder AtomicGroup(this IRegexBuilder builder, Action<IRegexBuilder> expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?>");
        expression(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Applies or disables the specified options within subexpression. For more information, see Regular Expression Options.
    /// </summary>
    /// <typeparam name="TCurrent"></typeparam>
    /// <param name="builder"></param>
    /// <param name="onOption"></param>
    /// <param name="offOption"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IRegexBuilder OptionGroup<TCurrent>(this TCurrent builder, Action<IOptionBuilder>? onOption, Action<IOptionBuilder>? offOption, Action<IRegexBuilder> expression)
        where TCurrent : IRegexBuilder, IOptionBuilder
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?");
        onOption?.Invoke(builder);
        if (offOption != null)
        {
            builder.AddRegexPattern("-");
            offOption(builder);
        }
        builder.AddRegexPattern(":");
        expression(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Applies or disables the specified options within subexpression. For more information, see Regular Expression Options.
    /// </summary>
    /// <typeparam name="TCurrent"></typeparam>
    /// <param name="builder"></param>
    /// <param name="onOption"></param>
    /// <param name="offOption"></param>
    /// <returns></returns>
    public static IRegexBuilder OptionGroup<TCurrent>(this TCurrent builder, Action<IOptionBuilder>? onOption, Action<IOptionBuilder>? offOption)
        where TCurrent : IRegexBuilder, IOptionBuilder
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?");
        onOption?.Invoke(builder);
        if (offOption != null)
        {
            builder.AddRegexPattern("-");
            offOption(builder);
        }
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Applies or disables the specified options within subexpression. For more information, see Regular Expression Options.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="option"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IRegexBuilder OptionGroup(this IRegexBuilder builder, string option, Action<IRegexBuilder> expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?");
        builder.AddRegexPattern(option);
        builder.AddRegexPattern(":");
        expression(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Applies or disables the specified options within subexpression. For more information, see Regular Expression Options.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static IRegexBuilder OptionGroup(this IRegexBuilder builder, string option)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?");
        builder.AddRegexPattern(option);
        builder.AddRegexPattern(")");
        return builder;
    }

    /// <summary>
    /// Inline comment. 
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="comment"></param>
    /// <returns></returns>
    public static IRegexBuilder Comment(this IRegexBuilder builder, string comment)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?#");
        builder.AddRegexPattern(comment);
        builder.AddRegexPattern(")");
        return builder;
    }
}