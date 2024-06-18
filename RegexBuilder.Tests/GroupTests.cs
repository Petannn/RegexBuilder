using RegexBuilder.Extensions;

namespace RegexBuilder.Tests;

internal class GroupTests
{
    [Test]
    public void GroupWithContent()
    {
        var builder = new RegexBuilder();
        builder.Group(q=>
            q.Add("a")
                .Add("b")
                .Or()
                .Add("c"));
        Assert.That(builder.ToString(), Is.EqualTo("(ab|c)"));
    }

    [Test]
    public void NamedGroupWithContent()
    {
        var builder = new RegexBuilder();
        builder.Group("name", q =>
            q.Add("a")
                .Add("b")
                .Or()
                .Add("c"));
        Assert.That(builder.ToString(), Is.EqualTo("(?<name>ab|c)"));
    }

    [Test]
    public void NonCapturingGroup()
    {
        var builder = new RegexBuilder();
        builder.NonCapturingGroup(q =>
            q.Add("a")
                .Add("b")
                .Or()
                .Add("c"));
        Assert.That(builder.ToString(), Is.EqualTo("(?:ab|c)"));
    }

    [Test]
    public void AtomicGroup()
    {
        var builder = new RegexBuilder();
        builder.AtomicGroup(q =>
            q.Add("a")
                .Add("b")
                .Or()
                .Add("c"));
        Assert.That(builder.ToString(), Is.EqualTo("(?>ab|c)"));
    }

    [Test]
    public void OptionGroup()
    {
        var builder = new RegexBuilder();
        builder.OptionGroup(q=>q.IgnoreCase(),null, q =>
            q.Add("a")
                .Add("b")
                .Or()
                .Add("c"));
        Assert.That(builder.ToString(), Is.EqualTo("(?i:ab|c)"));
    }

    [Test]
    public void OptionGroup2Params()
    {
        var builder = new RegexBuilder();
        builder.OptionGroup(q => q.IgnoreCase().SingleLineMode(), null, q =>
            q.Add("a")
                .Add("b")
                .Or()
                .Add("c"));
        Assert.That(builder.ToString(), Is.EqualTo("(?is:ab|c)"));
    }

    [Test]
    public void OptionGroupOff2Params()
    {
        var builder = new RegexBuilder();
        builder.OptionGroup(null, q => q.IgnoreCase().SingleLineMode(), q =>
            q.Add("a")
                .Add("b")
                .Or()
                .Add("c"));
        Assert.That(builder.ToString(), Is.EqualTo("(?-is:ab|c)"));
    }

    [Test]
    public void OptionGroupOnOff()
    {
        var builder = new RegexBuilder();
        builder.OptionGroup(q=>q.DoNotCaptureUnnamedGroups(), q => q.IgnoreCase().SingleLineMode(), q =>
            q.Add("a")
                .Add("b")
                .Or()
                .Add("c"));
        Assert.That(builder.ToString(), Is.EqualTo("(?n-is:ab|c)"));
    }

    [Test]
    public void OptionGroupOpen()
    {
        var builder = new RegexBuilder();
        builder.OptionGroup(q => q.DoNotCaptureUnnamedGroups(), q => q.IgnoreCase().SingleLineMode());
        Assert.That(builder.ToString(), Is.EqualTo("(?n-is)"));
    }

    [Test]
    public void CommentGroup()
    {
        var builder = new RegexBuilder();
        builder.Comment("comment sentence");
        Assert.That(builder.ToString(), Is.EqualTo("(?#comment sentence)"));
    }
}