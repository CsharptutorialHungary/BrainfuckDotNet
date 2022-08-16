using System.Collections;
using System.Text;

namespace BrainFuckDotNet.Domain
{
    internal sealed class Loop : IInstruction, IEnumerable<IInstruction>, IEquatable<Loop?>
    {
        public IList<IInstruction> Instructions { get; set; }

        public Loop()
        {
            Instructions = new List<IInstruction>();
        }

        public void Add(IInstruction item)
        {
            Instructions.Add(item);
        }


        public IEnumerator<IInstruction> GetEnumerator()
        {
            return Instructions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Instructions.GetEnumerator();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Loop);
        }

        public bool Equals(Loop? other)
        {
            if (other == null)
                return false;

            for (int i = 0; i < Instructions.Count; i++)
            {
                if (!Instructions[i].Equals(other.Instructions[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            for (int i = 0; i < Instructions.Count; i++)
            {
                hash.Add(Instructions[i]);
            }
            return hash.ToHashCode();
        }

        public string ToCharp(int indentation)
        {
            StringBuilder result = new StringBuilder(1024);
            result.AppendLine("while (mem[i] != 0)");
            result.AppendLine("{");
            foreach (var instruction in this)
            {
                if (instruction is Loop)
                    result.Append(instruction.ToCharp(indentation+2));
                else
                    result.Append(instruction.ToCharp(indentation+1));
            }
            result.AppendLine("}");
            return result.ToString();
        }
    }
}
