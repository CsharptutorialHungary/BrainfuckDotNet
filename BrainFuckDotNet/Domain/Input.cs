namespace BrainFuckDotNet.Domain
{
    /// <summary>
    /// ,
    /// </summary>
    internal record struct Input : IInstruction
    {
        public string ToCharp(int indentation)
        {
            return "mem[i] = console.Read();".Indent(indentation);
        }
    }
}
