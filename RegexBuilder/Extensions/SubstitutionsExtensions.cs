using System.Globalization;

namespace RegexBuilder.Extensions
{
    public static class SubstitutionsExtensions
    {
        public static IRegexBuilder Placeholder(this IRegexBuilder builder, int placeholderNumber)
        {
            builder.Append(Substitutions.Placeholder);
            builder.Append(placeholderNumber.ToString());
            return builder;
        }

        public static IRegexBuilder Placeholder(this IRegexBuilder builder, string groupName)
        {
            builder.Append(Substitutions.Placeholder);
            builder.Append(string.Format(CultureInfo.InvariantCulture, "{{0}}", groupName));
            return builder;
        }

        public static IRegexBuilder PlaceholderAsDollar(this IRegexBuilder builder)
        {
            builder.Append(Substitutions.Placeholder);
            builder.Append(Substitutions.Placeholder);
            return builder;
        }

        public static IRegexBuilder CopyWholeMatch(this IRegexBuilder builder)
        {
            builder.Append(Substitutions.Placeholder);
            builder.Append("&");
            return builder;
        }

        public static IRegexBuilder CopyWholeTextBeforeMatch(this IRegexBuilder builder)
        {
            builder.Append(Substitutions.Placeholder);
            builder.Append("`");
            return builder;
        }
        public static IRegexBuilder CopyWholeTextAfterMatch(this IRegexBuilder builder)
        {
            builder.Append(Substitutions.Placeholder);
            builder.Append("'");
            return builder;
        }

        public static IRegexBuilder CopyLastCapturedMatch(this IRegexBuilder builder)
        {
            builder.Append(Substitutions.Placeholder);
            builder.Append("+");
            return builder;
        }

        public static IRegexBuilder CopyInputText(this IRegexBuilder builder)
        {
            builder.Append(Substitutions.Placeholder);
            builder.Append("_");
            return builder;
        }
    }
}
