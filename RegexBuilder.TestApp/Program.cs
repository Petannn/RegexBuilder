using System.Text.RegularExpressions;
using RegexBuilder.Conditions;
using RegexBuilder.Groups;


namespace RegexBuilder.TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRegexBuilder v = new RegexBuilder();
            
            IGroup group = new NamedGroup("world");

            group.AddCondition(new AnyWorld(MetaChars.Any));
            v.AddCondition(group);
            v.AddCondition(MetaChars.WhiteSpace, new Quantifier(1, null));
            v.AddCondition(new BackReference("world"));

            var r = v.Build();
            Console.WriteLine(r);


            var matches = r.Matches("hello hello world world 1234 1234 ");

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
