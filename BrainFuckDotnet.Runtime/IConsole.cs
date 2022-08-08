namespace BrainFuckDotnet.Runtime
{
    public interface IConsole
    {
        byte Read();
        void Write(byte value);
    }
}
