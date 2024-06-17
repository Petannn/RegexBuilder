using RegexBuilder.Extensions;

namespace RegexBuilder.Tests
{
    internal class GroupTests
    {
        [Test]
        public void GroupWithContent()
        {
            var builder = new RegexBuilder();
            builder.Group(q=>
                q.Add("a")
                    .Add("b")
                    .Or()
                    .Add("c"));
            Assert.AreEqual("(ab|c)", builder.ToString());
        }

        [Test]
        public void NamedGroupWithContent()
        {
            var builder = new RegexBuilder();
            builder.Group("name", q =>
                q.Add("a")
                    .Add("b")
                    .Or()
                    .Add("c"));
            Assert.AreEqual("(?<name>ab|c)", builder.ToString());
        }
    }
}
