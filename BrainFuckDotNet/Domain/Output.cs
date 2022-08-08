namespace BrainFuckDotNet.Domain
{
    /// <summary>
    /// .
    /// </summary>
    internal record struct Output : IInstruction
    {
        public string ToCharp(int indentation)
        {
            return "console.Write(mem[i])".Indent(indentation);
        }
    }
}
