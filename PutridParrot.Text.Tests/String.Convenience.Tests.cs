using System.Diagnostics.CodeAnalysis;

namespace PutridParrot.Text.Tests;

/// <summary>
/// Just to ensure code is calling the correct methods
/// </summary>
[ExcludeFromCodeCoverage]
[TestFixture]
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
    
    // GetOrDefault
    
    [Test]
    public void GetOrDefault_IfNull_ExpectDefault()
    {
        string s = null!;
        Assert.That(s.OrDefault("Hello"), Is.EqualTo("Hello"));
    }

    [Test]
    public void GetOrDefault_IfEmpty_ExpectEmpty()
    {
        var s = string.Empty;
        Assert.That(s.OrDefault("Hello"), Is.EqualTo(s));
    }
    
    [Test]
    public void GetOrDefault_IfWhitespace_ExpectWhitespace()
    {
        const string s = "  ";
        Assert.That(s.OrDefault("Hello"), Is.EqualTo(s));
    }
    
    [Test]
    public void GetOrDefault_WithNonNullNonEmptyNonWhitespace_ExpectOriginalValue()
    {
        var s = "Hello World";
        Assert.That(s.OrDefault("Hello"), Is.EqualTo(s));
    }
    
    // IsNull
    
    [Test]
    public void IsNull_WithNull_ExpectTrue()
    {
        string? s = null;
        Assert.That(s.IsNull(), Is.True);
    }
    
    [Test]
    public void IsNull_WithEmpty_ExpectFalse()
    {
        var s = string.Empty;
        Assert.That(s.IsNull(), Is.False);
    }
    
    [Test]
    public void IsNull_WithWhiteSpace_ExpectFalse()
    {
        var s = "   ";
        Assert.That(s.IsNull(), Is.False);
    }
    
    // IsEmpty
    
    [Test]
    public void IsEmpty_WithNull_ExpectFalse()
    {
        string? s = null;
        Assert.That(s.IsEmpty(), Is.False);
    }
    
    [Test]
    public void IsEmpty_WithEmpty_ExpectTrue()
    {
        var s = string.Empty;
        Assert.That(s.IsEmpty(), Is.True);
    }
    
    [Test]
    public void IsEmpty_WithWhiteSpace_ExpectFalse()
    {
        var s = "   ";
        Assert.That(s.IsEmpty(), Is.False);
    }
    
    // IsWhitespace

    [Test]
    public void IsWhiteSpace_WithEmpty_ExpectFalse()
    {
        var s = string.Empty;
        Assert.That(s.IsWhiteSpace(), Is.False);
    }
    
    [Test]
    public void IsWhiteSpace_WithWhiteSpace_ExpectTrue()
    {
        var s = "   ";
        Assert.That(s.IsWhiteSpace(), Is.True);
    }
    
    // ToResolvedString
    
    [Test]
    public void ToResolvedString_WithNull_ExpectNullString()
    {
        string? s = null;
        Assert.That(s.ToResolvedString(), Is.EqualTo("<null>"));
    }
    
    [Test] 
    public void ToResolvedString_WithEmpty_ExpectEmptyString()
    {
        var s = string.Empty;
        Assert.That(s.ToResolvedString(), Is.EqualTo("<empty>"));
    }
    
    [Test] 
    public void ToResolvedString_WithWhiteSpace_ExpectWhitespaceString()
    {
        var s = "   "; 
        Assert.That(s.ToResolvedString(), Is.EqualTo("<whitespace>"));
    }
    
    [Test] 
    public void ToResolvedString_WithNonNullNonEmptyNonWhiteSpace_ExpectOriginalString()
    {
        var s = "Hello World"; 
        Assert.That(s.ToResolvedString(), Is.EqualTo(s));
    }
}