using System.Text;

namespace PutridParrot.Text;

public static partial class StringExtensions
{
    /// <summary>
    /// Converts a string to a stream, using the specified encoding
    /// </summary>
    /// <param name="s"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static Stream ToStream(this string s, Encoding encoding) =>
        new MemoryStream(encoding.GetBytes(s));
    
    /// <summary>
    /// Converts a string to a stream, using UTF8 encoding
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static Stream ToStream(this string s) => 
        ToStream(s, Encoding.UTF8);
}
