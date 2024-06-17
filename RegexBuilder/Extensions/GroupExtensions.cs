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

        public static IRegexBuilder OptionGroup(this IRegexBuilder builder, Action<IRegexBuilder> optionExpression, Action<IRegexBuilder> expression)
        {
            builder.Append("(?");
            optionExpression(builder);
            builder.Append(")");

            expression(builder);

            builder.Append("(?-");
            optionExpression(builder);
            builder.Append(")");

            return builder;
        }

        public static IRegexBuilder OptionGroup(this IRegexBuilder builder, string optionExpression, Action<IRegexBuilder> expression)
        {
            builder.Append("(?");
            builder.Append(optionExpression);
            builder.Append(")");

            expression(builder);

            builder.Append("(?-");
            builder.Append(optionExpression);
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
