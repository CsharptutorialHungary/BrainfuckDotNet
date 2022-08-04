namespace BrainFuckDotnet.Runtime
{
    /// <summary>
    /// Represents a BrainFuck exception
    /// </summary>
    [Serializable]
    public class BrainFuckException : Exception
    {
        public BrainFuckException() : base()
        {
        }

        public BrainFuckException(string? message) : base(message)
        {
        }

        public BrainFuckException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}