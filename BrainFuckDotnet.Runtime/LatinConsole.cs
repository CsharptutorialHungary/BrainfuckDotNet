using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFuckDotnet.Runtime
{
    //TODO: Fix later
    public abstract class LatinConsole : IConsole
    {
        protected readonly string _charTable;

        protected LatinConsole()
        {
            StringBuilder chars = new(256);
            for (int i = 0; i < 255; i++)
            {
                chars.Append(Encoding.Latin1.GetString(new byte[] { (byte)i }));
            }
            _charTable = chars.ToString();
        }

        public abstract byte Read();

        public abstract void Write(byte value);
    }
}
