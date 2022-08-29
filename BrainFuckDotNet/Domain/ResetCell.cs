namespace BrainFuckDotNet.Domain
{
    internal struct ResetCell : IInstruction
    {
        public string ToCharp(int indentation)
        {
            return "mem[i] = 0;".Indent(indentation);
        }
    }
}
