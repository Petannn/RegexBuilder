using RegexBuilder.Extensions;

namespace RegexBuilder.Tests;

internal class OpenCloseTests
{
    [Test]
    public void Group()
    {
        var builder = new RegexBuilder();
        builder.BeginGroup();
        builder.EndGroup();
        Assert.That(builder.ToString(), Is.EqualTo("()"));
    }

    [Test]
    public void NamedGroup()
    {
        var builder = new RegexBuilder();
        builder.BeginGroup("name");
        builder.EndGroup();
        Assert.That(builder.ToString() , Is.EqualTo("(?<name>)"));
    }

    [Test]
    public void AtomicGroup()
    {
        var builder = new RegexBuilder();
        builder.BeginAtomicGroup();
        builder.EndGroup();
        Assert.That(builder.ToString(), Is.EqualTo("(?>)"));
    }

    [Test]
    public void NonCapturedGroup()
    {
        var builder = new RegexBuilder();
        builder.BeginNonCapturingGroup();
        builder.EndGroup();
        Assert.That(builder.ToString(), Is.EqualTo("(?:)"));
    }

    [Test]
    public void OptionGroup()
    {
        var builder = new RegexBuilder();
        builder.OptionGroup(q => q.IgnoreCase(), null);
        builder.Add("ab").Or().Add("c");
        builder.OptionGroup(null, q=>q.IgnoreCase());

        Assert.That(builder.ToString(), Is.EqualTo("(?i)ab|c(?-i)"));
    }

    [Test]
    public void OptionGroup2()
    {
        var builder = new RegexBuilder();
        builder.OptionGroup(q => q.IgnoreCase(),null, q=>q.Add("ab").Or().Add("c"));
        Assert.That(builder.ToString(), Is.EqualTo("(?i:ab|c)"));
    }

    [Test]
    public void OptionGroup3()
    {
        var builder = new RegexBuilder();
        builder.OptionGroup(q => q.IgnoreCase(), q=>q.MultiLineMode(), q => q.Add("ab").Or().Add("c"));
        Assert.That(builder.ToString(), Is.EqualTo("(?i-m:ab|c)"));
    }

    [Test]
    public void OpenOptionGroupOnOption()
    {
        var builder = new RegexBuilder();
        builder.OptionGroup(q => q.IgnoreCase(), null);
        Assert.That(builder.ToString(), Is.EqualTo("(?i)"));
    }

    [Test]
    public void OpenOptionGroupOffOption()
    {
        var builder = new RegexBuilder();
        builder.OptionGroup(null, q => q.IgnoreCase());
        Assert.That(builder.ToString(), Is.EqualTo("(?-i)"));
    }

    [Test]
    public void OpenOptionGroupOnOffOption()
    {
        var builder = new RegexBuilder();
        builder.OptionGroup(q => q.MultiLineMode(), q => q.IgnoreCase());
        Assert.That(builder.ToString(), Is.EqualTo("(?m-i)"));
    }
}