namespace RegexBuilder.Extensions
{
    public static  class AlternationExtensions
    {
        public static IRegexBuilder Or(this IRegexBuilder builder)
        {
            return builder.Append("|");
        }

        public static IRegexBuilder Condition(this IRegexBuilder builder, Action<IRegexBuilder> expression, Action<IRegexBuilder> yes)
        {
            builder.Append("(?(");
            expression(builder);
            builder.Append(")");
            yes(builder);
            builder.Append(")");
            return builder;
        }

        public static IRegexBuilder Condition(this IRegexBuilder builder, string expression, Action<IRegexBuilder> yes)
        {
            builder.Append("(?(");
            builder.Append(expression);
            builder.Append(")");
            yes(builder);
            builder.Append(")");
            return builder;
        }

        public static IRegexBuilder Condition(this IRegexBuilder builder, Action<IRegexBuilder> expression, string yes)
        {
            builder.Append("(?(");
            expression(builder);
            builder.Append(")");
            builder.Append(yes);
            builder.Append(")");
            return builder;
        }

        public static IRegexBuilder Condition(this IRegexBuilder builder, string expression, string yes)
        {
            builder.Append("(?(");
            builder.Append(expression);
            builder.Append(")");
            builder.Append(yes);
            builder.Append(")");
            return builder;
        }

        public static IRegexBuilder Condition(this IRegexBuilder builder, Action<IRegexBuilder> expression, Action<IRegexBuilder> yes, Action<IRegexBuilder> no)
        {
            builder.Append("(?(");
            expression(builder);
            builder.Append(")");
            yes(builder);
            builder.Or();
            no(builder);
            builder.Append(")");
            return builder;
        }
    }
}
