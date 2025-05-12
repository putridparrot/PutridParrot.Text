using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace PutridParrot.Text.Tests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class StringCaseTests
{
    [TestCase("hello", "Hello")]
    [TestCase("HELLO", "HELLO")]
    [TestCase("hello world", "Hello world")]
    [TestCase("", "")]
    [TestCase(" ", " ")]
    [TestCase(null, null)]
    public void ToFirstUpper_ShouldConvertFirstCharacterToUpperCase(string? input, string? expected)
    {
        var result = input.ToFirstUpper();
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("Hello", "hello")]
    [TestCase("HELLO", "hELLO")]
    [TestCase("Hello World", "hello World")]
    [TestCase("", "")]
    [TestCase(" ", " ")]
    [TestCase(null, null)]
    public void ToFirstLower_ShouldConvertFirstCharacterToLowerCase(string? input, string? expected)
    {
        var result = input.ToFirstLower();
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ToFirstUpper_WithTurkishCulture_ShouldHandleSpecialCases()
    {
        var turkishCulture = new CultureInfo("tr-TR");
        var input = "istanbul";
        var result = input.ToFirstUpper(turkishCulture);
        Assert.That(result, Is.EqualTo("İstanbul"));
    }

    [Test]
    public void ToFirstLower_WithTurkishCulture_ShouldHandleSpecialCases()
    {
        var turkishCulture = new CultureInfo("tr-TR");
        var input = "İSTANBUL";
        var result = input.ToFirstLower(turkishCulture);
        Assert.That(result, Is.EqualTo("iSTANBUL"));
    }
}