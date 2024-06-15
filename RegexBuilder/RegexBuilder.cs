using System.Text.RegularExpressions;

namespace RegexBuilder
{
    public interface IRegexBuilder : IConstrainBuilder<RegexBuilder, IRegexBuilder>
    {
        Regex Build(RegexOptions option = RegexOptions.None);
    }
    
    public class RegexBuilder : ConstrainBuilder<RegexBuilder,IRegexBuilder>, IRegexBuilder
    {
        public Regex Build(RegexOptions options)
        {
            return new Regex(ToRegexPattern(), options);
        }
    }
}
