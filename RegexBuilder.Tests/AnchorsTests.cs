using RegexBuilder.Extensions;

namespace RegexBuilder.Tests
{
    internal class AnchorsTests
    {
        [Test]
        public void LineStart()
        {
            IRegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder
                .LineStart()
                .Digit()
                .ExactTimes(3);

            Assert.That(regexBuilder.ToString(), Is.EqualTo("^\\d{3}"));
        }

        [Test]
        public void LineEnd()
        {
            IRegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder
                .Add("-")
                .Digit()
                .ExactTimes(3)
                .LineEnd();

            Assert.That(regexBuilder.ToString(), Is.EqualTo("-\\d{3}$"));
        }

        [Test]
        public void StringStart()
        {
            IRegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder
                .StringStart()
                .Digit()
                .ExactTimes(3);

            Assert.That(regexBuilder.ToString(), Is.EqualTo("\\A\\d{3}"));
        }

        [Test]
        public void StringEnd()
        {
            IRegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder
                .Add("-")
                .Digit()
                .ExactTimes(3)
                .StringEnd();

            Assert.That(regexBuilder.ToString(), Is.EqualTo("-\\d{3}\\z"));
        }

        [Test]
        public void StringEndOrLastLineEnd()
        {
            IRegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder
                .Add("-")
                .Digit()
                .ExactTimes(3)
                .StringEndOrLastLineEnd();

            Assert.That(regexBuilder.ToString(), Is.EqualTo("-\\d{3}\\Z"));
        }

        [Test]
        public void PreviousMatchEnd()
        {
            IRegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder
                .PreviousMatchEnd()
                .Add("(")
                .Digit()
                .Add(")");

            Assert.That(regexBuilder.ToString(), Is.EqualTo("\\G\\(\\d\\)"));
        }

        [Test]
        public void Boundary()
        {
            IRegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder
                .WordBoundary()
                .WordChar().OneOrMoreTimes()
                .WhiteSpace()
                .WordChar().OneOrMoreTimes()
                .WordBoundary();

            Assert.That(regexBuilder.ToString(), Is.EqualTo("\\b\\w+\\s\\w+\\b"));
        }

        [Test]
        public void NotBoundary()
        {
            IRegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder
                .NonWordBoundary()
                .Add("end")
                .WordChar().ZeroOrMoreTimes()
                .WordBoundary();

            Assert.That(regexBuilder.ToString(), Is.EqualTo("\\Bend\\w*\\b"));
        }
    }
}
