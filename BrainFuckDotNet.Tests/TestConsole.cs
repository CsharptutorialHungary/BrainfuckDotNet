using System.Text;

namespace BrainFuckDotNet.Tests
{
    internal class TestConsole : LatinConsole
    {
        private readonly StringBuilder _result;

        public TestConsole()
        {
            _result = new(256);
        }

        public int WriteCount { get; set; }

        public override byte Read()
        {
            return 0;
        }

        public override void Write(byte value)
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
