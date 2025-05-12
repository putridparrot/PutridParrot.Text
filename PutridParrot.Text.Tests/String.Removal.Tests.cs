using System.Diagnostics.CodeAnalysis;

namespace PutridParrot.Text.Tests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class StringRemovalTests
{
    [Test]
    public void RemoveLf_WithNullString_ReturnsNull()
    {
        string? input = null;
        Assert.That(input.RemoveLf(), Is.Null);
    }

    [Test]
    public void RemoveCr_WithNullString_ReturnsNull()
    {
        string? input = null;
        Assert.That(input.RemoveCr(), Is.Null);
    }

    [TestCase("Hello\rWorld", "HelloWorld")]
    [TestCase("Hello\r\rWorld", "HelloWorld")]
    [TestCase("HelloWorld", "HelloWorld")]
    [TestCase("", "")]
    public void RemoveCr_RemovesAllCarriageReturns(string input, string expected)
    {
        Assert.That(input.RemoveLf(), Is.EqualTo(expected));
    }
    
    [TestCase("Hello\nWorld", "HelloWorld")]
    [TestCase("Hello\n\nWorld", "HelloWorld")]
    [TestCase("HelloWorld", "HelloWorld")]
    [TestCase("", "")]
    public void RemoveLf_RemovesAllLineFeeds(string input, string expected)
    {
        Assert.That(input.RemoveCr(), Is.EqualTo(expected));
    }

    [TestCase("Hello\r\nWorld", "HelloWorld")]
    [TestCase("Hello\n\rWorld", "HelloWorld")]
    [TestCase("Hello\r\r\n\nWorld", "HelloWorld")]
    [TestCase("Hello\nWorld\r", "HelloWorld")]
    [TestCase("HelloWorld", "HelloWorld")]
    [TestCase("", "")]
    public void RemoveLineBreaks_RemovesAllLineBreaks(string input, string expected)
    {
        Assert.That(input.RemoveLineBreaks(), Is.EqualTo(expected));
    }

    [TestCase("Hello World", "HelloWorld")]
    [TestCase("Hello  World", "HelloWorld")]
    [TestCase("Hello\tWorld", "HelloWorld")]
    [TestCase("Hello \t World", "HelloWorld")]
    [TestCase("HelloWorld", "HelloWorld")]
    [TestCase("", "")]
    public void RemoveWhitespace_RemovesAllWhitespace(string input, string expected)
    {
        Assert.That(input.RemoveWhitespace(), Is.EqualTo(expected));
    }

    [TestCase("Hello\r\nWorld", "Hello World")]
    [TestCase("Hello\nWorld", "Hello World")]
    [TestCase("Hello\rWorld", "Hello World")]
    [TestCase("Hello\r\n\r\nWorld", "Hello World")]
    [TestCase("Hello\n\nWorld", "Hello World")]
    [TestCase("HelloWorld", "HelloWorld")]
    [TestCase("", "")]
    public void ToSingleLine_ReplacesLineBreaksWithSpace(string input, string expected)
    {
        Assert.That(input.ToSingleLine(), Is.EqualTo(expected));
    }

    [Test]
    public void RemoveLineBreaks_WithMultipleLineBreakTypes_RemovesAll()
    {
        var input = "Line1\rLine2\nLine3\r\nLine4";
        var expected = "Line1Line2Line3Line4";
        Assert.That(input.RemoveLineBreaks(), Is.EqualTo(expected));
    }

    [Test]
    public void RemoveWhitespace_WithMultipleWhitespaceTypes_RemovesAll()
    {
        var input = "Hello \t \n \r World";
        var expected = "HelloWorld";
        Assert.That(input.RemoveWhitespace(), Is.EqualTo(expected));
    }

    [Test]
    public void ToSingleLine_PreservesSpacesBetweenWords()
    {
        var input = "Hello  World\r\nNew  Line";
        var expected = "Hello  World New  Line";
        Assert.That(input.ToSingleLine(), Is.EqualTo(expected));
    }
}