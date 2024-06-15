using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RegexBuilder.Conditions;
using RegexBuilder.Groups;

namespace RegexBuilder.Tests
{
    internal class GroupTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Atomic()
        {
            IGroup group = new AtomicGroup();
            group.AddCondition(new Literal("a"));
            group.AddCondition(new Literal("ab"));
            var regex = new Regex(group.ToRegexPattern()+"c");
            Assert.False(regex.IsMatch("abc"));
        }

        [Test]
        public void Atomic2()
        {
            IGroup group = new AtomicGroup();
            group.AddCondition(new Literal("a"));
            group.AddCondition(new Literal("ab"));
            var regex = new Regex(group.ToRegexPattern() + "c");
            Assert.True(regex.IsMatch("ac"));
        }
    }
}
