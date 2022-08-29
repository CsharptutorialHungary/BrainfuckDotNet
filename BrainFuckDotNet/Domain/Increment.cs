namespace BrainFuckDotNet.Domain
{
    /// <summary>
    /// +, -
    /// </summary>
    internal record struct Increment : IInstruction, IValue
    {
        public int Value { get; set; }

        public string ToCharp(int indentation)
        {
            if (Value == 0)
                return string.Empty;
            else if (Value == 1)
                return "mem[i]++;".Indent(indentation);
            else if (Value == -1)
                return "mem[i]--;".Indent(indentation);
            else
                return "mem[i] = (byte)(mem[i] + Value)".Indent(indentation);
        }
    }
}
