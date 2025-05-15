using System.Text.RegularExpressions;

namespace PutridParrot.Text;

public static partial class StringExtensions
{
    /// <summary>
    /// Remove the LF's from a string
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string? RemoveLf(this string? s) => 
        s?.Replace("\r", string.Empty);

    /// <summary>
    /// Removes the new lines from a string
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string? RemoveCr(this string? s) => 
        s?.Replace("\n", string.Empty);

    /// <summary>
    /// Remove \r and \n characters from the string
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string? RemoveLineBreaks(this string? s) =>
        s?.RemoveLf().RemoveCr();
    
    /// <summary>
    /// Removes whitespace from a string
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string RemoveWhitespace(this string s) => 
        Regex.Replace(s, @"\s+", String.Empty);
    
    /// <summary>
    /// Makes a string a "single line" by remove CR and LF characters
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ToSingleLine(this string s) => 
        Regex.Replace(s,  @"(\r\n?|\n)+", " ");
}
