using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BrainFuckDotnet.Runtime;

using BrainFuckDotNet.Domain;

namespace BrainFuckDotNet.Parsing
{
    internal static class Tokenizer
    {
        public static IList<IInstruction> Tokenize(string program)
        {
            int i = 0;
            int opened = 0;
            int closed = 0;
            List<IInstruction> result = Tokenize(program, ref i, ref opened, ref closed);

            if (opened > closed)
            {
                throw ExceptionFactory.Create(Error.ErrorUnclosedLoop, i);
            }

            return result;
        }

        private static List<IInstruction> Tokenize(string program, ref int i, ref int opened, ref int closed)
        {
            List<IInstruction> result = new List<IInstruction>();
            while (i < program.Length)
            {
                char c = program[i];
                IInstruction? instruction = Create(c);
                if (instruction != null)
                {
                    result.Add(instruction);
                }
                else if (c == '[')
                {
                    i++;
                    ++opened;
                    Loop loop = new Loop { Instructions = Tokenize(program, ref i, ref opened, ref closed) };
                    result.Add(loop);
                }
                else if (c == ']')
                {
                    ++closed;

                    if (closed > opened)
                        throw ExceptionFactory.Create(Error.ErrorTooManyLoopClose, i);

                    return result;
                }
                i++;
            }
            return result;
        }

        private static IInstruction? Create(char c)
        {
            return c switch
            {
                '+' => new Increment { Value = 1 },
                '-' => new Increment { Value = -1 },
                '>' => new PointerMove { Value = 1 },
                '<' => new PointerMove { Value = -1 },
                '.' => new Output(),
                ',' => new Input(),
                _ => null,
            };
        }
    }
}
