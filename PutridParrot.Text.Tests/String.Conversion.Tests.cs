using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PutridParrot.Text.Tests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class StringConversionTests
{
    [Test]
    public void ToStream_WithDefaultEncoding_CreatesStreamWithUTF8()
    {
        var str = "Hello, World!";
        using var stream = str.ToStream();
        var bytes = new byte[stream.Length];
        stream.ReadExactly(bytes, 0, (int)stream.Length);
        Assert.That(Encoding.UTF8.GetString(bytes), Is.EqualTo(str));
    }

    [Test]
    public void ToStream_WithCustomEncoding_CreatesStreamWithSpecifiedEncoding()
    {
        var str = "Hello, World!";
        var encoding = Encoding.ASCII;
        using var stream = str.ToStream(encoding);
        var bytes = new byte[stream.Length];
        stream.ReadExactly(bytes, 0, (int)stream.Length);
        Assert.That(encoding.GetString(bytes), Is.EqualTo(str));
    }

    [Test]
    public void ToStream_WithUnicodeString_PreservesContent()
    {
        var str = "Hello, 世界!";
        using var stream = str.ToStream();
        var bytes = new byte[stream.Length];
        stream.ReadExactly(bytes, 0, (int)stream.Length);
        Assert.That(Encoding.UTF8.GetString(bytes), Is.EqualTo(str));
    }
}