using System.Text;

namespace PutridParrot.Text;

public static partial class StringExtensions
{
    public static Stream ToStream(this string str, Encoding encoding) =>
        new MemoryStream(encoding.GetBytes(str));
    
    public static Stream ToStream(this string str) => 
        ToStream(str, Encoding.UTF8);
}
