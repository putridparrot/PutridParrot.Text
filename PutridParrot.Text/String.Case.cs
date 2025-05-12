using System.Globalization;

namespace PutridParrot.Text;

public static partial class StringExtensions
{
    public static string ToFirstUpper(this string s) =>
        s.ToFirstUpper(CultureInfo.InvariantCulture);
    public static string ToFirstLower(this string s) =>
        s.ToFirstLower(CultureInfo.InvariantCulture);
    public static string ToFirstUpper(this string s, CultureInfo culture) =>
        s.ToFirst(culture, char.ToUpper);
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
