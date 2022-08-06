namespace BrainFuckDotNet.Domain
{
    /// <summary>
    /// +, -
    /// </summary>
    internal record struct Increment : IInstruction
    {
        public int Value { get; set; }
    }
}
