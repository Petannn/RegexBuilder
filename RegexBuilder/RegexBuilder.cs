using System.Text;

namespace RegexBuilder
{
    public interface IRegexBuilder
    {
        IRegexBuilder Append(string text);
        string ToString();
    }

    public class RegexBuilder : IRegexBuilder
    {
        private readonly StringBuilder _builder = new();

        public IRegexBuilder Append(string text)
        {
            _builder.Append(text);
            return this;
        }

        public override string ToString()
        {
            return _builder.ToString();
        }
    }
}
