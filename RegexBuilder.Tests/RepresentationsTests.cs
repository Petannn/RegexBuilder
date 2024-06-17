using RegexBuilder.Extensions;

namespace RegexBuilder.Tests
{
    internal class RepresentationsTests
    {
        [Test]
        public void Octal()
        {
            var builder = new RegexBuilder();
            builder.OctalRepresentation((char)120);
            Assert.AreEqual("\\170", builder.ToString());
        }

        [Test]
        public void Octal2()
        {
            var builder = new RegexBuilder();
            builder.OctalRepresentation((char)4);
            Assert.AreEqual("\\004", builder.ToString());
        }

        [Test]
        public void Hex()
        {
            var builder = new RegexBuilder();
            builder.HexadecimalRepresentation((char)255);
            Assert.AreEqual("\\xff", builder.ToString());
        }

        [Test]
        public void Hex2()
        {
            var builder = new RegexBuilder();
            builder.HexadecimalRepresentation((char)0);
            Assert.AreEqual("\\x00", builder.ToString());
        }

        [Test]
        public void ASCIIControlChar()
        {
            var builder = new RegexBuilder();
            builder.ASCIIControlChar((char)255);
            Assert.AreEqual("\\c00ff", builder.ToString());
        }

        [Test]
        public void Unicode()
        {
            var builder = new RegexBuilder();
            builder.Unicode(65535);
            Assert.AreEqual("\\uffff", builder.ToString());
        }

        [Test]
        public void Unicode2()
        {
            var builder = new RegexBuilder();
            builder.Unicode(0);
            Assert.AreEqual("\\u0000", builder.ToString());
        }
    }
}
