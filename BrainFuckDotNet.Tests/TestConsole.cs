using System.Text;

namespace BrainFuckDotNet.Tests
{
    internal class TestConsole : IConsole
    {
        private readonly StringBuilder _result;

        public TestConsole()
        {
            _result = new(256);
        }

        public int WriteCount { get; private set; }

        public byte Read()
        {
            return 0;
        }

        public void Write(byte value)
        {
            _result.Append((char)value);
            WriteCount++;
        }

        public override string ToString()
        {
            return _result.ToString();
        }
    }
}
