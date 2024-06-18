using RegexBuilder.Extensions;

namespace RegexBuilder.Tests;

internal class AlternationTests
{
    [Test]
    public void Yes()
    {
        var builder = new RegexBuilder();
        builder.Condition("expression","yes");

        Assert.That(builder.ToString(), Is.EqualTo("(?(expression)yes)"));
    }

    [Test]
    public void Yes2()
    {
        var builder = new RegexBuilder();
        builder.Condition(q => q.Add("expression"), q => q.Add("yes"));

        Assert.That(builder.ToString(), Is.EqualTo("(?(expression)yes)"));
    }

    [Test]
    public void Yes3()
    {
        var builder = new RegexBuilder();
        builder.Condition(q => q.Add("expression"), "yes");

        Assert.That(builder.ToString(), Is.EqualTo("(?(expression)yes)"));
    }
    [Test]
    public void Yes4()
    {
        var builder = new RegexBuilder();
        builder.Condition("expression",q=>q.Add("yes"));

        Assert.That(builder.ToString(), Is.EqualTo("(?(expression)yes)"));
    }

    [Test]
    public void YesNo()
    {
        var builder = new RegexBuilder();
        builder.Condition("expression", "yes", "no");
            
        Assert.That(builder.ToString(), Is.EqualTo("(?(expression)yes|no)"));
    }

    [Test]
    public void YesNo2()
    {
        var builder = new RegexBuilder();
        builder.Condition(q => q.Add("expression"), q => q.Add("yes"), q => q.Add("no"));

        Assert.That(builder.ToString(), Is.EqualTo("(?(expression)yes|no)"));
    }


    [Test]
    public void YesNo3()
    {
        var builder = new RegexBuilder();
        builder.Condition("expression", q => q.Add("yes"), q => q.Add("no"));

        Assert.That(builder.ToString(), Is.EqualTo("(?(expression)yes|no)"));
    }

    [Test]
    public void YesNo4()
    {
        var builder = new RegexBuilder();
        builder.Condition("expression", "yes", q => q.Add("no"));

        Assert.That(builder.ToString(), Is.EqualTo("(?(expression)yes|no)"));
    }

    [Test]
    public void YesNo5()
    {
        var builder = new RegexBuilder();
        builder.Condition("expression", q => q.Add("yes"),"no");

        Assert.That(builder.ToString(), Is.EqualTo("(?(expression)yes|no)"));
    }

    [Test]
    public void YesNo6()
    {
        var builder = new RegexBuilder();
        builder.Condition(q=>q.Add("expression"), q => q.Add("yes"), "no");

        Assert.That(builder.ToString(), Is.EqualTo("(?(expression)yes|no)"));
    }

    [Test]
    public void YesNo7()
    {
        var builder = new RegexBuilder();
        builder.Condition(q => q.Add("expression"), "yes", q=>q.Add("no"));

        Assert.That(builder.ToString(), Is.EqualTo("(?(expression)yes|no)"));
    }

    [Test]
    public void YesNo8()
    {
        var builder = new RegexBuilder();
        builder.Condition(q => q.Add("expression"), "yes", "no");

        Assert.That(builder.ToString(), Is.EqualTo("(?(expression)yes|no)"));
    }
}