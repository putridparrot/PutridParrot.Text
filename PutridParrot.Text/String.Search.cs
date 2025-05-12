namespace PutridParrot.Text;

public static partial class StringExtensions
{
    /// <summary>
    /// Finds the first index for any of the specified strings in the target string,
    /// starting from the specified index.
    /// </summary>
    /// <param name="s">The string to search</param>
    /// <param name="anyOf">An array of all the strings to search for</param>
    /// <param name="startIndex">The start index for the search</param>
    /// <returns></returns>
    public static int IndexOfAny(this string s, string[] anyOf, int startIndex = 0)
    {
        ArgumentNullException.ThrowIfNull(s);
        if (startIndex < 0 || startIndex > s.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index is out of range.");
        }

        var pos = -1;
        foreach (var value in anyOf)
        {
            var index = s.IndexOf(value, startIndex, StringComparison.Ordinal);
            if (index >= 0)
            {
                pos = pos == -1 ? index : Math.Min(pos, index);
            }
        }
        return pos;
    }
}
