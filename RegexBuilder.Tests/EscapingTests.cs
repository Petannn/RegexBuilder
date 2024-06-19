using RegexBuilder.Extensions;

namespace RegexBuilder.Tests;

internal class EscapingTests
{
    [Test]
    public void EscapeAdd()
    {
        var builder = new RegexBuilder();
        builder.Add("example.Invoke()");

        Assert.That(builder.ToString(), Is.EqualTo("example\\.Invoke\\(\\)"));
    }

    [Test]
    public void EscapeBackslash()
    {
        var builder = new RegexBuilder();
        builder.Add("\\hello");

        Assert.That(builder.ToString(), Is.EqualTo("\\\\hello"));
    }

    [Test]
    public void EscapeEscaped()
    {
        var builder = new RegexBuilder();
        builder.Add("\\w");
        var regex = builder.Build();

        Assert.That(builder.ToString(), Is.EqualTo("\\\\w"));
        Assert.True(regex.IsMatch("\\w"));
    }
}