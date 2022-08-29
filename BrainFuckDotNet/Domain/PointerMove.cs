namespace BrainFuckDotNet.Domain
{
    /// <summary>
    /// <, >
    /// </summary>
    internal record struct PointerMove : IInstruction, IValue
    {
        public int Value { get; set; }

        public string ToCharp(int indentation)
        {
            if (Value == 0)
                return string.Empty;
            else if (Value == 1)
                return "i++".Indent(indentation);
            else if (Value == -1)
                return "i--".Indent(indentation);
            else
                return "i += Value".Indent(indentation);
        }
    }
}
