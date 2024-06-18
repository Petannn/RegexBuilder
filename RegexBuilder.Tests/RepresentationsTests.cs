using RegexBuilder.Extensions;

namespace RegexBuilder.Tests;

internal class RepresentationsTests
{
    [TestCase((char)120, "\\170")]
    [TestCase((char)4, "\\004")]
    public void Octal(char ch, string expected)
    {
        var builder = new RegexBuilder();
        builder.OctalRepresentation(ch);
        Assert.That(builder.ToString(), Is.EqualTo(expected));
    }

    [TestCase((char)255, "\\xff")]
    [TestCase((char)0, "\\x00")]
    public void Hex(char ch, string expected)
    {
        var builder = new RegexBuilder();
        builder.HexadecimalRepresentation(ch);
        Assert.That(builder.ToString(), Is.EqualTo(expected));
    }
    
    [Test]
    public void ASCIIControlChar()
    {
        var builder = new RegexBuilder();
        builder.ASCIIControlChar((char)255);
        Assert.That(builder.ToString(), Is.EqualTo("\\c00ff"));
    }

    [Test]
    public void Unicode()
    {
        var builder = new RegexBuilder();
        builder.Unicode(65535);
        Assert.That(builder.ToString(), Is.EqualTo("\\uffff"));
    }

    [Test]
    public void Unicode2()
    {
        var builder = new RegexBuilder();
        builder.Unicode(0);
        Assert.That(builder.ToString(), Is.EqualTo("\\u0000"));
    }
}