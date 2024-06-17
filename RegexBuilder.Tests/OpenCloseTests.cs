using RegexBuilder.Extensions;

namespace RegexBuilder.Tests
{
    internal class OpenCloseTests
    {
        [Test]
        public void Group()
        {
            var builder = new RegexBuilder();
            builder.BeginGroup();
            builder.EndGroup();
            Assert.AreEqual("()", builder.ToString());
        }

        [Test]
        public void NamedGroup()
        {
            var builder = new RegexBuilder();
            builder.BeginGroup("name");
            builder.EndGroup();
            Assert.AreEqual("(?<name>)", builder.ToString());
        }

        [Test]
        public void AtomicGroup()
        {
            var builder = new RegexBuilder();
            builder.BeginAtomicGroup();
            builder.EndGroup();
            Assert.AreEqual("(?>)", builder.ToString());
        }

        [Test]
        public void NonCapturedGroup()
        {
            var builder = new RegexBuilder();
            builder.BeginNonCapturingGroup();
            builder.EndGroup();
            Assert.AreEqual("(?:)", builder.ToString());
        }
    }
}
