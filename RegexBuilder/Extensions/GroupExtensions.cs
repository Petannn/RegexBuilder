namespace RegexBuilder.Extensions
{
    public static class GroupExtensions
    {
        public static IRegexBuilder BeginGroup(this IRegexBuilder builder)
        {
            return builder.Append("(");
        }

        public static IRegexBuilder BeginGroup(this IRegexBuilder builder, string name)
        {
            builder.Append("(?<");
            builder.Append(name);
            builder.Append(">");
            return builder;
        }

        public static IRegexBuilder BeginNonCapturingGroup(this IRegexBuilder builder)
        {
            return builder.Append("(?:");
        }

        public static IRegexBuilder BeginAtomicGroup(this IRegexBuilder builder)
        {
            return builder.Append("(?>");
        }

        public static IRegexBuilder EndGroup(this IRegexBuilder builder)
        {
            return builder.Append(")");
        }

        public static IRegexBuilder Group(this IRegexBuilder builder, Action<IRegexBuilder> expression)
        {
            builder.BeginGroup();
            expression(builder);
            builder.EndGroup();
            return builder;
        }

        public static IRegexBuilder Group(this IRegexBuilder builder,string name, Action<IRegexBuilder> expression)
        {
            builder.BeginGroup(name);
            expression(builder);
            builder.Append(")");
            return builder;
        }

        public static IRegexBuilder NonCapturingGroup(this IRegexBuilder builder, Action<IRegexBuilder> expression)
        {
            builder.Append("(?:");
            expression(builder);
            builder.Append(")");
            return builder;
        }

        public static IRegexBuilder AtomicGroup(this IRegexBuilder builder, Action<IRegexBuilder> expression)
        {
            builder.Append("(?>");
            expression(builder);
            builder.Append(")");
            return builder;
        }

        public static IRegexBuilder OptionGroup<TCurrent>(this TCurrent builder, Action<IOptionBuilder>? onOption, Action<IOptionBuilder>? offOption, Action<IRegexBuilder> expression) 
            where TCurrent : IRegexBuilder , IOptionBuilder
        {
            builder.Append("(?");
            onOption?.Invoke(builder);
            if (offOption != null)
            {
                builder.Append("-");
                offOption(builder);
            }
            builder.Append(":");
            expression(builder);
            builder.Append(")");
            return builder;
        }

        public static IRegexBuilder OptionGroup<TCurrent>(this TCurrent builder, Action<IOptionBuilder>? onOption, Action<IOptionBuilder>? offOption) 
            where TCurrent : IRegexBuilder, IOptionBuilder
        {
            builder.Append("(?");
            onOption?.Invoke(builder);
            if (offOption != null)
            {
                builder.Append("-");
                offOption(builder);
            }
            builder.Append(")");
            return builder;
        }

        public static IRegexBuilder OptionGroup(this IRegexBuilder builder, string option, Action<IRegexBuilder> expression)
        {
            builder.Append("(?");
            builder.Append(option);
            builder.Append(":");
            expression(builder);
            builder.Append(")");
            return builder;
        }

        public static IRegexBuilder OptionGroup(this IRegexBuilder builder, string option)
        {
            builder.Append("(?");
            builder.Append(option);
            builder.Append(")");
            return builder;
        }

        public static IRegexBuilder Comment(this IRegexBuilder builder, string comment)
        {
            builder.Append("(?#");
            builder.Append(comment);
            builder.Append(")");
            return builder;
        }
    }
}
