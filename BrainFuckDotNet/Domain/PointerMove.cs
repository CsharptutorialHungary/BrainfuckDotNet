namespace BrainFuckDotNet.Domain
{
    /// <summary>
    /// <, >
    /// </summary>
    internal record struct PointerMove : IInstruction
    {
        public int Value { get; set; }
    }
}
