namespace BrainFuckDotNet.Domain
{
    internal interface IInstruction
    {
        string ToCharp(int indentation);
    }
}
