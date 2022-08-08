
using BrainFuckDotnet.Runtime;

namespace BrainFuckDotNet
{
    internal class SytemConsole : LatinConsole
    {
        public override byte Read()
        {
            int value = Console.Read();

            if (value < 0)
                return 0;

            if (value > 255)
                return 255;

            return (byte)value;
        }

        public override void Write(byte value)
        {
            char c = _charTable[value];
            Console.Write(c);
        }
    }
}
