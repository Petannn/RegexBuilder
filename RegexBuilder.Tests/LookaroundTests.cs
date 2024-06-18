using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegexBuilder.Extensions;

namespace RegexBuilder.Tests
{
    internal class LookaroundTests
    {
        [Test]
        public void Before()
        {
            var builder = new RegexBuilder();
            builder.Before("check");

            Assert.That(builder.ToString(), Is.EqualTo("(?=check)"));
        }

        [Test]
        public void NotBefore()
        {
            var builder = new RegexBuilder();
            builder.NotBefore("check");

            Assert.That(builder.ToString(), Is.EqualTo("(?!check)"));
        }

        [Test]
        public void Behind()
        {
            var builder = new RegexBuilder();
            builder.Behind("check");

            Assert.That(builder.ToString(), Is.EqualTo("(?<=check)"));
        }

        [Test]
        public void NotBehind()
        {
            var builder = new RegexBuilder();
            builder.NotBehind("check");

            Assert.That(builder.ToString(), Is.EqualTo("(?<!check)"));
        }
    }
}
