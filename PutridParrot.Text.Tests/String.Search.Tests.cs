using System.Diagnostics.CodeAnalysis;

namespace PutridParrot.Text.Tests;

[ExcludeFromCodeCoverage]
public class StringSearchingTests
{
    [Test]
    public void IndexOfAny_FindTheFirstOccurrenceOfOnOfTheSuppliedStrings_ExpectMatchOnDoo()
    {
        var s = "Scooby, Scooby Doo where are you?";
        var result = s.IndexOfAny(["you", "Doo"]);
        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void IndexOfAny_FindWhereNothingMatches_ExpectMinusOne()
    {
        var s = "Scooby, Scooby Doo where are you?";
        var result = s.IndexOfAny(["Thelma", "Fred"]);
        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void IndexOfAny_WhereStringIsNull_ExpectArgumentNullException()
    {
        string s = null!;
        Assert.Throws<ArgumentNullException>(() => s.IndexOfAny(["you", "Doo"]));
    }

    [Test]
    [TestCase(-1)]
    [TestCase(100)]
    public void IndexOfAny_StartIndexOutsideRange_ExpectException(int startIndex)
    {
        var s = "Scooby, Scooby Doo where are you?";
        Assert.Throws<ArgumentOutOfRangeException>(() => s.IndexOfAny(["you", "Doo"], startIndex));
    }

}
