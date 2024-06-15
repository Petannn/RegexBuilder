using System.Globalization;

namespace RegexBuilder.Conditions
{
    public class BackReference :ICondition
    {
        private readonly string _pattern;

        public BackReference(string name)
        {
            _pattern = string.Format(CultureInfo.InvariantCulture, "\\k<{0}>", name);
        }

        public BackReference(int id)
        {
            _pattern = string.Format(CultureInfo.InvariantCulture, "\\{0}", id);
        }

        public string ToRegexPattern()
        {
            return _pattern;
        }
    }
}
