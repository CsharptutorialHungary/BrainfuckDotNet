namespace BrainFuckDotNet.Domain
{
    /// <summary>
    /// .
    /// </summary>
    internal record struct Output : IInstruction
    {
        public string ToCharp(int indentation)
        {
            return "Console.Write((char)mem[i]);".Indent(indentation);
        }
    }
}
