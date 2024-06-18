using System.Globalization;
using System.Text.RegularExpressions;
using RegexBuilder.Extensions;

namespace RegexBuilder.TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder
                .Add("Hello")
                .WhiteSpace()
                .Group(q =>
                    q.Add("world")
                        .Or()
                        .Add("universe"));

            var regex = regexBuilder.Build(); // pattern: Hello\s(world|universe)
            Console.WriteLine("pattern: " + regex);
            var matches = regex.Matches("Hello world Hello universe"); // match1: "Hello world" match2:  "Hello universe"
            for (int i = 0; i < matches.Count; i++)
            {
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "match{0}: \"{1}\"", i+1, matches[i]));
            }
        }
    }
}
