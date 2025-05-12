using System.Diagnostics.CodeAnalysis;

namespace PutridParrot.Text.Tests;

/// <summary>
/// Just to ensure code is calling the correct methods
/// </summary>
[ExcludeFromCodeCoverage]
public class StringConvenienceTests
{
    // IsNullOrEmpty

    [Test]
    public void IsNullOrEmpty_WithNull_ExpectTrue()
    {
        string? s = null;
        Assert.That(s.IsNullOrEmpty(), Is.True);
    }
    
    [Test]
    public void IsNullOrEmpty_WithEmpty_ExpectTrue()
    {
        var s = string.Empty;
        Assert.That(s.IsNullOrEmpty(), Is.True);
    }

    [Test]
    public void IsNullOrEmpty_WithWhiteSpace_ExpectFalse()
    {
        var s = "   ";
        Assert.That(s.IsNullOrEmpty(), Is.False);
    }
    
    [Test]
    public void IsNullOrEmpty_WithText_ExpectFalse()
    {
        var s = " Hello World ";
        Assert.That(s.IsNullOrEmpty(), Is.False);
    }
    
    // IsNullOrWhitespace
    
    [Test]
    public void IsNullOrWhiteSpace_WithNull_ExpectTrue()
    {
        string? s = null;
        Assert.That(s.IsNullOrWhiteSpace(), Is.True);
    }
    
    [Test]
    public void IsNullOrWhiteSpace_WithEmpty_ExpectTrue()
    {
        var s = string.Empty;
        Assert.That(s.IsNullOrWhiteSpace(), Is.True);
    }

    [Test]
    public void IsNullOrWhiteSpace_WithWhiteSpace_ExpectTrue()
    {
        var s = "   ";
        Assert.That(s.IsNullOrWhiteSpace(), Is.True);
    }
    
    [Test]
    public void IsNullOrWhiteSpace_WithText_ExpectFalse()
    {
        var s = " Hello World ";
        Assert.That(s.IsNullOrWhiteSpace(), Is.False);
    }
}