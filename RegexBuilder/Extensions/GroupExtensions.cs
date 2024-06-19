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

    public static IRegexBuilder Group(this IRegexBuilder builder, Action<IRegexBuilder> expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.BeginGroup();
        expression(builder);
        builder.EndGroup();
        return builder;
    }

    public static IRegexBuilder Group(this IRegexBuilder builder, string name, Action<IRegexBuilder> expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.BeginGroup(name);
        expression(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    public static IRegexBuilder NonCapturingGroup(this IRegexBuilder builder, Action<IRegexBuilder> expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?:");
        expression(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

    public static IRegexBuilder AtomicGroup(this IRegexBuilder builder, Action<IRegexBuilder> expression)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?>");
        expression(builder);
        builder.AddRegexPattern(")");
        return builder;
    }

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

    public static IRegexBuilder OptionGroup(this IRegexBuilder builder, string option)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?");
        builder.AddRegexPattern(option);
        builder.AddRegexPattern(")");
        return builder;
    }

    public static IRegexBuilder Comment(this IRegexBuilder builder, string comment)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.AddRegexPattern("(?#");
        builder.AddRegexPattern(comment);
        builder.AddRegexPattern(")");
        return builder;
    }
}