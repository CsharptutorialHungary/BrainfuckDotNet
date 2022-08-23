using System.Text;

namespace BrainFuckDotNet.Domain
{
    internal static class Extensions
    {
        public static string Indent(this string input, int level)
        {
            string spaces = "".PadLeft(level * 4, ' ');
            return spaces + input + "\r\n";
        }

        public static StringBuilder IndentedAdd(this StringBuilder input, string str, int level)
        {
            string spaces = "".PadLeft(level * 4, ' ');
            input.Append(spaces);
            input.Append(str);
            input.AppendLine();
            return input;
        }
    }
}
