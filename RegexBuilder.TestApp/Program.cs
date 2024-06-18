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
                .Group(g =>
                      g.WordChar().OneOrMoreTimes()
                       .Dot().ZeroOrOneTime())
                .OneOrMoreTimes()
                .Add("@")
                .Group(g =>
                      g.WordChar().OneOrMoreTimes()
                       .Dot()).OneOrMoreTimes()
                .WordChar().AtLeastTimes(2);

            regexBuilder.Group(q => q.Add("@").OneOrMoreTimes()).AsFewAsPossibleTimes();



            var regex = regexBuilder.Build();
            Console.WriteLine(regex);
            var matches = regex.Matches("xxx.yyyyyyy@zzzz.com   cccc.xxx.yyyyyyy@zzzz.com aaaa@bbb.com cccc@dddd.eeee.com  xxx.yyyyyyyzzzz.com  xxx.yyyyyyy@zzzz");

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
