using System.Text.RegularExpressions;
using RegexBuilder.Extensions;

namespace RegexBuilder.TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var regexBuilder = new RegexBuilder();

            regexBuilder
                .Group(g =>
                      g.WordChar()
                       .OneOrMoreTimes()
                       .Dot()
                       .ZeroOrOneTime())
                .OneOrMoreTimes()
                .Add("@")
                .Group(g =>
                      g.WordChar()
                       .OneOrMoreTimes()
                       .Dot()
                       .ZeroOrOneTime()
                ).OneOrMoreTimes();

            regexBuilder.Group(q => q.Add("@").OneOrMoreTimes()).AsFewAsPossibleTimes();

            var regex = regexBuilder.Build(RegexOptions.Multiline);
            Console.WriteLine(regex);
            var matches = regex.Matches("xxxx.yyyyy@zzzzzz.com");

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
