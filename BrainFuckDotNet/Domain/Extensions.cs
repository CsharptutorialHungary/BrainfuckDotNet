namespace BrainFuckDotNet.Domain
{
    internal static class Extensions
    {
        public static string Indent(this string input, int level)
        {
            string spaces = "".PadLeft(level * 4, ' ');
            return spaces + input;
        }
    }
}
