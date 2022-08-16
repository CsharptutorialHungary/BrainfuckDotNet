namespace BrainFuckDotNet.Domain
{
    /// <summary>
    /// <, >
    /// </summary>
    internal record struct PointerMove : IInstruction
    {
        public int Value { get; set; }

        public string ToCharp(int indentation)
        {
            if (Value < 0)
                return "i--;".Indent(indentation);
            else if (Value > 0)
                return "i++;".Indent(indentation);
            else
                return string.Empty;
        }
    }
}
