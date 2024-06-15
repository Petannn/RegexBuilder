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
        [Test]
        public void Atomic()
        {
            IGroup group = new AtomicGroup();
            group.AddCondition(new Literal("a"));
            group.AddCondition(new Literal("b"));
            group.AddCondition(new Literal("c"));
            Assert.AreEqual("(?>a|b|c)", group.ToRegexPattern());
        }

        [Test]
        public void Balancing()
        {
            IGroup group = new BalancingGroup("ab", "cd");
            group.AddCondition(new Literal("a"));
            group.AddCondition(new Literal("b"));
            group.AddCondition(new Literal("c"));
            Assert.AreEqual("(?<ab-cd>abc)", group.ToRegexPattern());
        }

        [Test]
        public void Capturing()
        {
            IGroup group = new CapturingGroup();
            group.AddCondition(new Literal("a"));
            group.AddCondition(new Literal("b"));
            group.AddCondition(new Literal("c"));
            Assert.AreEqual("abc", group.ToRegexPattern());
        }

        [Test]
        public void NonCapturing()
        {
            IGroup group = new NoncapturingGroup();
            group.AddCondition(new Literal("a"));
            group.AddCondition(new Literal("b"));
            group.AddCondition(new Literal("c"));
            Assert.AreEqual("(?:a|b|c)", group.ToRegexPattern());
        }

        [Test]
        public void Matched()
        {
            IGroup group = new MatchedGroup();
            group.AddCondition(new Literal("a"));
            group.AddCondition(new Literal("b"));
            group.AddCondition(new Literal("c"));
            Assert.AreEqual("(abc)", group.ToRegexPattern());
        }

        [Test]
        public void Nammed()
        {
            IGroup group = new NamedGroup("name");
            group.AddCondition(new Literal("a"));
            group.AddCondition(new Literal("b"));
            group.AddCondition(new Literal("c"));
            Assert.AreEqual("(?<name>abc)", group.ToRegexPattern());
        }


        [Test]
        public void NegativeLookahead()
        {
            IGroup group = new NegativeLookaheadGroup();
            group.AddCondition(new Literal("a"));
            group.AddCondition(new Literal("b"));
            group.AddCondition(new Literal("c"));
            Assert.AreEqual("(?!abc)", group.ToRegexPattern());
        }

        [Test]
        public void PositiveLookahead()
        {
            IGroup group = new PositiveLookaheadGroup();
            group.AddCondition(new Literal("a"));
            group.AddCondition(new Literal("b"));
            group.AddCondition(new Literal("c"));
            Assert.AreEqual("(?=abc)", group.ToRegexPattern());
        }

        [Test]
        public void NegativeLookbehind()
        {
            IGroup group = new NegativeLookbehindGroup();
            group.AddCondition(new Literal("a"));
            group.AddCondition(new Literal("b"));
            group.AddCondition(new Literal("c"));
            Assert.AreEqual("(?<!abc)", group.ToRegexPattern());
        }

        [Test]
        public void PositiveLookbehind()
        {
            IGroup group = new PositiveLookbehindGroup();
            group.AddCondition(new Literal("a"));
            group.AddCondition(new Literal("b"));
            group.AddCondition(new Literal("c"));
            Assert.AreEqual("(?<=abc)", group.ToRegexPattern());
        }

        [Test]
        public void Options()
        {
            IGroup group = new OptionsGroup();
            group.AddCondition(new Literal("a"));
            group.AddCondition(new Literal("b"));
            group.AddCondition(new Literal("c"));
            Assert.AreEqual("(?imnsx-imnsx:abc)", group.ToRegexPattern());
        }

        [Test]
        public void Nested()
        {
            IGroup named = new NamedGroup("name");
            IGroup nested = new NoncapturingGroup();
            
            nested.AddCondition(new Literal("a"));
            nested.AddCondition(new Literal("b"));
            nested.AddCondition(new Literal("c"));

            named.AddCondition(nested);

            Assert.AreEqual("(?<name>(?:a|b|c))", named.ToRegexPattern());
        }

    }
}
