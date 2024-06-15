using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using RegexBuilder.Conditions;

namespace RegexBuilder.Tests
{
    internal class RangeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Correct()
        {
            IRegexBuilder builder = new RegexBuilder();
            builder.AddCondition(new Literal("a"), new ExpressionQuantifier(2,2));
            var regex = builder.Build();

            var matches = regex.Matches("aaa aaaa aa");
            Assert.AreEqual(4, matches.Count);
        }

        [Test]
        public void Min()
        {
            IRegexBuilder builder = new RegexBuilder();
            builder.AddCondition(new Literal("a"), new ExpressionQuantifier(1, null));
            var regex = builder.Build();

            var matches = regex.Matches("aaa aaaa aa");
            Assert.AreEqual(3, matches.Count);
        }

        [Test]
        public void Max()
        {
            IRegexBuilder builder = new RegexBuilder();
            builder.AddCondition(new Literal("a"), new ExpressionQuantifier(1,2));
            var regex = builder.Build();

            var matches = regex.Matches("aaa aaaa aa");
            Assert.AreEqual(5, matches.Count);
        }
    }
}
