using System.Text.RegularExpressions;
using RegexBuilder.Conditions;
using RegexBuilder.Groups;

namespace RegexBuilder.Tests
{
    public class HelloWorldTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HelloWorld()
        {
            IRegexBuilder builderA = new RegexBuilder();
            builderA.AddCondition(new Literal("Hello"));
            builderA.AddCondition(MetaChars.Any);
            builderA.AddCondition(new Literal("world"));
            var regexHelloWorld = builderA.Build();

            var match = regexHelloWorld.Match("Hello world");
            Assert.True(match.Success);
        }

        [Test]
        public void WorldHello()
        {
            IRegexBuilder builderA = new RegexBuilder();
            builderA.AddCondition(new Literal("Hello"));
            builderA.AddCondition(MetaChars.Any);
            builderA.AddCondition(new Literal("world"));
            var regexHelloWorld = builderA.Build();

            var match = regexHelloWorld.Match("world Hello");
            Assert.False(match.Success);
        }


        [Test]
        public void HelloWorldWorldHello()
        {
            IRegexBuilder builderA = new RegexBuilder();
            builderA.AddCondition(new Literal("Hello"));
            builderA.AddCondition(MetaChars.Any);
            builderA.AddCondition(new Literal("world"));

            IRegexBuilder builderB = new RegexBuilder();
            builderB.AddCondition(new Literal("world"));
            builderB.AddCondition(MetaChars.Any);
            builderB.AddCondition(new Literal("Hello"));

            IRegexBuilder builder = new RegexBuilder();

            var group = new NoncapturingGroup();
            group.AddCondition(builderA);
            group.AddCondition(builderB);
            builder.AddCondition(group);
            var regex = builder.Build();

           var match = regex.Matches("Hello world world Hello");
           Assert.AreEqual(2, match.Count);
        }
    }
}