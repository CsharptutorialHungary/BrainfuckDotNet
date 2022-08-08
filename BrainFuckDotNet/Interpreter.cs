using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BrainFuckDotnet.Runtime;

using BrainFuckDotNet.Domain;
using BrainFuckDotNet.Parsing;

namespace BrainFuckDotNet
{
    internal class Interpreter
    {
        private readonly byte[] _memory;
        private readonly IConsole _console;
        private int _memoryPointer;

        public int Count { get; private set; }

        public Interpreter(IConsole console)
        {
            _memory = new byte[30_000];
            _memoryPointer = 0;
            _console = console;
        }

        public void Reset()
        {
            Array.Fill<byte>(_memory, 0);
            _memoryPointer = 0;
            Count = 0;
        }

        public void Execute(string program)
        {
            Reset();
            IList<IInstruction> instructions = Tokenizer.Tokenize(program);
            Execute(instructions);
        }

        private void Execute(IList<IInstruction> instructions)
        {
            foreach(var instruction in instructions)
            {
                try
                {
                    if (instruction is Increment increment)
                    {
                        int result = _memory[_memoryPointer] + increment.Value;
                        _memory[_memoryPointer] = (byte)result;
                    }
                    else if (instruction is PointerMove pointerMove)
                    {
                        _memoryPointer += pointerMove.Value;
                    }
                    else if (instruction is Loop loop)
                    {
                        while (_memory[_memoryPointer] != 0)
                        {
                            Execute(loop.Instructions);
                        }
                    }
                    else if (instruction is Output)
                    {
                        _console.Write(_memory[_memoryPointer]);
                    }
                    else if (instruction is Input)
                    {
                        _memory[_memoryPointer] = _console.Read();
                    }
                }
                catch (Exception ex)
                {
                    throw ExceptionFactory.Create(Error.ErrorRuntimeError, ex, ex.Message);
                }
            }
        }
    }
}
