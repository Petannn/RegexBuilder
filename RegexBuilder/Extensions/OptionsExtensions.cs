namespace RegexBuilder.Extensions
{
    public static class OptionsExtensions
    {
        public static IRegexBuilder IgnoreCase(this IRegexBuilder builder)
        {
            return builder.Append("i");
        }

        public static IRegexBuilder MultiLineMode(this IRegexBuilder builder)
        {
            return builder.Append("m");
        }

        public static IRegexBuilder SingleLineMode(this IRegexBuilder builder)
        {
            return builder.Append("s");
        }

        public static IRegexBuilder DoNotCaptureUnnamedGroups(this IRegexBuilder builder)
        {
            return builder.Append("n");
        }

        public static IRegexBuilder IgnoreUnescapedWhitespaceInPattern(this IRegexBuilder builder)
        {
            return builder.Append("x");
        }
    }
}
