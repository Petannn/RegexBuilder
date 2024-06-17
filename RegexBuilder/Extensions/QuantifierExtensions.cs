using System.Globalization;

namespace RegexBuilder.Extensions
{
    public static class QuantifierExtensions
    {
        public static IRegexBuilder ZeroOrMoreTimes(this IRegexBuilder builder)
        {
            return builder.Append("*");
        }

        public static IRegexBuilder OneOrMoreTimes(this IRegexBuilder builder)
        {
            return builder.Append("+");
        }

        public static IRegexBuilder ZeroOrOneTime(this IRegexBuilder builder)
        {
            return builder.Append("?");
        }

        public static IRegexBuilder ExactTimes(this IRegexBuilder builder, int times)
        {
            return builder.Append(string.Format(CultureInfo.InvariantCulture, "{{{0}}}", times));
        }

        public static IRegexBuilder AtLeastTimes(this IRegexBuilder builder, int minimum)
        {
            return builder.Append(string.Format(CultureInfo.InvariantCulture, "{{{0},}}", minimum));
        }

        public static IRegexBuilder BetweenTimes(this IRegexBuilder builder, uint minimum, int? maximum)
        {
            return builder.Append(string.Format(CultureInfo.InvariantCulture, "{{{0},{1}}}", minimum, maximum));
        }

        public static IRegexBuilder AsFewAsPossibleTimes(this IRegexBuilder builder)
        {
            return builder.Append("?");
        }
    }
}
