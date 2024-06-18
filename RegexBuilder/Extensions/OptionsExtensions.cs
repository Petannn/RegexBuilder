namespace RegexBuilder.Extensions
{
    public static class OptionsExtensions
    {
        public static IOptionBuilder IgnoreCase(this IOptionBuilder builder)
        {
            return builder.AddOption("i");
        }

        public static IOptionBuilder MultiLineMode(this IOptionBuilder builder)
        {
            return builder.AddOption("m");
        }

        public static IOptionBuilder SingleLineMode(this IOptionBuilder builder)
        {
            return builder.AddOption("s");
        }

        public static IOptionBuilder DoNotCaptureUnnamedGroups(this IOptionBuilder builder)
        {
            return builder.AddOption("n");
        }

        public static IOptionBuilder IgnoreUnescapedWhitespaceInPattern(this IOptionBuilder builder)
        {
            return builder.AddOption("x");
        }
    }
}
