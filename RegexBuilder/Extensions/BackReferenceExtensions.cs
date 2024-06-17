namespace RegexBuilder.Extensions
{
    public static class BackReferenceExtensions
    {

        public static IRegexBuilder Ref(this IRegexBuilder builder, string name)
        {
            builder.Append("\\k<");
            builder.Append(name);
            builder.Append(">");
            return builder;
        }

        public static IRegexBuilder Ref(this IRegexBuilder builder, int groupOrder)
        {
            builder.Append("\\");
            builder.Append(groupOrder.ToString());
            return builder;
        }
    }
}
