using System.Text;

using BrainFuckDotNet.Domain;

namespace BrainFuckDotNet
{
    internal static class CodeGenerator
    {
        private const int DefaultIndent = 4;

        public static string Generate(IList<IInstruction> instructions, string nameSpace, string className)
        {
            StringBuilder final = new StringBuilder(Properties.Resources.Template);
            final.Replace("%NameSpaceName%", nameSpace);
            final.Replace("%ClassName%", className);

            StringBuilder generated = new();

            foreach (var instruction in instructions)
            {
                generated.Append(instruction.ToCharp(DefaultIndent));
            }

            final.Replace("%Generated%", generated.ToString());
            
            return final.ToString();
        }
    }
}
