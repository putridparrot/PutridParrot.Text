using System.Diagnostics.CodeAnalysis;

namespace PutridParrot.Text.Tests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class StringSplitTests
{
    [Test]
    public void Split_WithStringSeparators_SplitsCorrectly()
    {
        var result = new List<string>();
        "a,b,c".Split([","], StringSplitOptions.None, s =>
        {
            result.Add(s.ToString());
        });
        Assert.That(result, Is.EqualTo(new[] { "a", "b", "c" }));
    }

    [Test]
    public void Split_WithCharSeparators_SplitsCorrectly()
    {
        var result = new List<string>();
        "a,b,c".Split([','], StringSplitOptions.None, s =>
        {
            result.Add(s.ToString());
        });
        Assert.That(result, Is.EqualTo(new[] { "a", "b", "c" }));
    }

    [Test]
    public void Split_EmptyString_InvokesActionOnce()
    {
        var called = 0;
        string.Empty.Split([","], StringSplitOptions.None, _ =>
        {
            called++;
        });
        Assert.That(called, Is.EqualTo(1));
    }

    [Test]
    public void Split_WithRemoveEmptyEntries_SkipsEmptyParts()
    {
        var result = new List<string>();
        "a,,c".Split([","], StringSplitOptions.RemoveEmptyEntries, s =>
        {
            result.Add(s.ToString());
        });
        Assert.That(result, Is.EqualTo(new[] { "a", "c" }));
    }

    [Test]
    public void Split_NullAction_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => 
            "test".Split([","], StringSplitOptions.None, null!));
    }
    
    [Test]
    public void Split_WithRemoveEmptyEntries2_SkipsEmptyParts()
    {
        var result = new List<string>();
        "a, ,c".Split([","], StringSplitOptions.RemoveEmptyEntries, s =>
        {
            result.Add(s.ToString());
        });
        Assert.That(result, Is.EqualTo(new[] { "a", "c" }));
    }

    //[Test]
    //public void SplitToSpans_WithRemoveEmptyEntries3_SkipsEmptyParts()
    //{
    //    var spans = "a, ,c".SplitAsSpan([","], StringSplitOptions.RemoveEmptyEntries);

    //    var result = new List<string>();
    //    foreach (var readOnlySpan in spans)
    //    {
    //        result.Add(readOnlySpan.ToString());
    //    }

    //    Assert.That(result, Is.EqualTo(new[] { "a", "c" }));
    //}
}