using RegexBuilder.Extensions;

namespace RegexBuilder.Tests;

internal class RefTests
{
    [Test]
    public void NameRef()
    {
        var builder = new RegexBuilder();
        builder.Ref("name");

        Assert.That(builder.ToString(), Is.EqualTo("\\k<name>"));
    }

    [Test]
    public void NumberRef()
    {
        var builder = new RegexBuilder();
        builder.Ref(1);

        Assert.That(builder.ToString(), Is.EqualTo("\\1"));
    }
}