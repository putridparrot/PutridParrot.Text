namespace PutridParrot.Text;

public static partial class StringExtensions
{
    /// <summary>
    /// A memory efficient splitter, calls the supplied action for each part of the string
    /// that is not empty, or if the StringSplitOptions.RemoveEmptyEntries is specified
    /// the action is only called for non empty parts. The action is passed the ReadOnlySpan
    /// of the part of the string that was split.
    /// </summary>
    /// <param name="s">This string to split</param>
    /// <param name="separators">The string separators to split on</param>
    /// <param name="options">Split options</param>
    /// <param name="action">The action that is passed the span of the string</param>
    public static void Split(this string s, string[] separators, StringSplitOptions options, Action<ReadOnlySpan<char>> action) =>
        Split(s, separators, options, action, s.IndexOfAny);

    /// <summary>
    /// A memory efficient splitter, calls the supplied action for each part of the string
    /// that is not empty, or if the StringSplitOptions.RemoveEmptyEntries is specified
    /// the action is only called for non empty parts. The action is passed the ReadOnlySpan
    /// of the part of the string that was split.
    /// </summary>
    /// <param name="s">This string to split</param>
    /// <param name="separators">The character separators to split on</param>
    /// <param name="options">Split options</param>
    /// <param name="action">The action that is passed the span of the string</param>
    public static void Split(this string s, char[] separators, StringSplitOptions options, Action<ReadOnlySpan<char>> action) =>
        Split(s, separators, options, action, s.IndexOfAny);

    private static void Split<T>(this string s, T[] separators, StringSplitOptions options, 
        Action<ReadOnlySpan<char>> action, Func<T[], int, int> indexOfAny)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (s.Length == 0)
        {
            IfValidInvokeAction(s, 0, 0, options, action);
        }
        else
        {
            var current = 0;
            int next;
            while ((next = indexOfAny(separators, current)) != -1)
            {
                IfValidInvokeAction(s, current, next, options, action);
                current = next + 1;
            }
            if (current <= s.Length)
            {
                IfValidInvokeAction(s, current, s.Length, options, action);
            }
        }
    }

    private static void IfValidInvokeAction(string s, int start, int end, 
        StringSplitOptions options, Action<ReadOnlySpan<char>> action)
    {
        var length = end - start;
        var span = s.AsSpan(start, length);

        if (options == StringSplitOptions.RemoveEmptyEntries)
        {
            if (start < end)
            {
                if (!span.IsWhiteSpace())
                {
                    action(span);
                }
            }
        }
        else
        {
            action(span);
        }
    }
}