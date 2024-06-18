using RegexBuilder.Extensions;

namespace RegexBuilder.Tests;

internal class CommonTests
{
    [Test]
    public void EscapeAdd()
    {
        var builder = new RegexBuilder();
        builder.Add("example.Invoke()");

        Assert.That(builder.ToString(), Is.EqualTo("example\\.Invoke\\(\\)"));
    }
}