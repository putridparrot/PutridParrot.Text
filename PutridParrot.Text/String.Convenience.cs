using System.Diagnostics.CodeAnalysis;

namespace PutridParrot.Text;

public static partial class StringExtensions
{
    /// <summary>
    /// Checks if the supplied string is null or empty
    /// </summary>
    /// <param name="s"></param>
    /// <returns>True if the string is null or empty</returns>
    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? s) => 
        string.IsNullOrEmpty(s);

    /// <summary>
    /// Checks if the supplied string is null or empty or just whitespace
    /// </summary>
    /// <param name="s"></param>
    /// <returns>True if the string is null or empty or whitespace</returns>
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? s) => 
        string.IsNullOrWhiteSpace(s);
    
    /// <summary>
    /// If the supplied string is null, return the default value, otherwise return the string.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static string? OrDefault(this string? s, string? defaultValue) => 
        s ?? defaultValue;

    /// <summary>
    /// Sometimes you just want to know if a string is null, not if it is empty or whitespace
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool IsNull([NotNullWhen(false)] this string? s) =>
        s is null;

    /// <summary>
    /// Sometimes you just want to know if a string is empty, not if it is null or whitespace
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool IsEmpty(this string? s) =>
        s?.Length == 0;
    
    /// <summary>
    /// Sometimes you just want to know if a string is whitespace, not if it is null or empty
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool IsWhiteSpace(this string? s) =>
        s is not null && s.Length != 0 && s.All(char.IsWhiteSpace);
    
    /// <summary>
    /// Returns a friendly string for the supplied string, if the string is null, empty or whitespace.
    /// This can be useful if you're simply outputting a string to the user, and want to provide
    /// more specific information on what the string is.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="nullString">The string to write if the string is null</param>
    /// <param name="emptyString">The string to write if the string is empty</param>
    /// <param name="whitespaceString">The string to write if the string is whitespace</param>
    /// <returns></returns>
    public static string ToResolvedString(this string? s, string nullString = "<null>", string emptyString = "<empty>", string whitespaceString = "<whitespace>" )
    {
        if (s.IsNull())
            return nullString;
        if(s.IsEmpty())
            return emptyString;
        if(s.IsWhiteSpace())
            return whitespaceString;
        
        return s;
    }
}