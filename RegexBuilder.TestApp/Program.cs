using System.Text.RegularExpressions;
using RegexBuilder.Conditions;
using RegexBuilder.Groups;


namespace RegexBuilder.TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRegexBuilder builder = new RegexBuilder();

            builder.Any(new Literal("ahoj"), new Literal("hi"), new Literal("ola"), new Literal("hello"));
            builder.SkipWhiteSpaces();
            builder.Any(new Literal("number"), new Literal("name"));
            builder.SkipWhiteSpaces();
            builder.Any(
                 b => b.If(new Literal("number"), new AnyWord(MetaChars.AnyDigit)),
                                b => b.If(new Literal("name"),   new AnyWord(MetaChars.WordCharacter)));

            var r = builder.Build();
            Console.WriteLine(r);


            var matches = r.Matches("hello number 1234 1234 ");

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
