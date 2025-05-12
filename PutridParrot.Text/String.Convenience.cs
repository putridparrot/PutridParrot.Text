namespace PutridParrot.Text;

public static partial class StringExtensions
{
    public static bool IsNullOrEmpty(this string s) => 
        string.IsNullOrEmpty(s);

    public static bool IsNullOrWhiteSpace(this string s) => 
        string.IsNullOrWhiteSpace(s);
}