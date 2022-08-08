using System.Text;

using BrainFuckDotNet.Domain;

namespace BrainFuckDotNet
{
    internal class CodeGenerator
    {
        public string Generate(IList<IInstruction> instructions, string nameSpace, string className)
        {
            StringBuilder final = new StringBuilder(Properties.Resources.Template);
            final.Replace("%NameSpaceName%", nameSpace);
            final.Replace("%ClassName%", className);

            StringBuilder generated = new StringBuilder();

            foreach (var instruction in instructions)
            {
                generated.Append(instruction.ToCharp(4));
            }

            final.Replace("%Generated%", generated.ToString());
            
            return generated.ToString();
        }
    }
}
