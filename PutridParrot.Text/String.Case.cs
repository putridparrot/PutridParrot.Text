using System.Globalization;

namespace PutridParrot.Text;

public static partial class StringExtensions
{
    /// <summary>
    /// Ensure the first character of the string is uppercase
    /// </summary>
    /// <param name="s">The initial string</param>
    /// <returns>A copy of the string with the first character as uppercase</returns>
    public static string ToFirstUpper(this string s) =>
        s.ToFirstUpper(CultureInfo.InvariantCulture);
    /// <summary>
    /// Ensure the first character of the string is lowercase
    /// </summary>
    /// <param name="s">This initial string</param>
    /// <returns>A copy of the string with the first character as lowercase</returns>
    public static string ToFirstLower(this string s) =>
        s.ToFirstLower(CultureInfo.InvariantCulture);
    /// <summary>
    /// Ensure the first character of the string is uppercase using the supplied CultureInfo
    /// </summary>
    /// <param name="s">This initial string</param>
    /// <param name="culture"></param>
    /// <returns>A copy of the string with the first character as uppercase</returns>
    public static string ToFirstUpper(this string s, CultureInfo culture) =>
        s.ToFirst(culture, char.ToUpper);
    /// <summary>
    /// Ensure the first character of the string is lower case using the supplied CultureInfo
    /// </summary>
    /// <param name="s">This initial string</param>
    /// <param name="culture"></param>
    /// <returns>A copy of the string with the first character as lowercase</returns>
    public static string ToFirstLower(this string s, CultureInfo culture) =>
        s.ToFirst(culture, char.ToLower);

    private static string ToFirst(this string s, CultureInfo culture, Func<char, CultureInfo, char> toCase)
    {
        return s.IsNullOrWhiteSpace() ? s : string.Create(s.Length, s, (chars, str) =>
        {
            chars[0] = toCase(str[0], culture);
            str.AsSpan(1).CopyTo(chars[1..]);
        });
    }
}
