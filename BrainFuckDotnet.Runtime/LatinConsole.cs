using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFuckDotnet.Runtime
{
    public abstract class LatinConsole : IConsole
    {
        protected readonly char[] _charTable;

        protected LatinConsole()
        {
            byte[] table = new byte[255];
            for (int i = 0; i<255; i++)
            {
                table[i] = (byte)i;
            }

            _charTable = Encoding.Latin1.GetChars(table);
        }

        public abstract byte Read();

        public abstract void Write(byte value);
    }
}
