using System.Reflection;

using BrainFuckDotnet.Runtime;

using BrainFuckDotNet.Domain;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace BrainFuckDotNet
{
    internal class Compiler
    {
        private readonly CSharpCompilationOptions _compilerOptions;
        private readonly HashSet<PortableExecutableReference> _references;

        private void ReferenceDotnet()
        {
            if (!(AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES") is string trusted))
                throw new InvalidOperationException("Can't locate Trusted platform assemblies");

            string[]? trustedAssembliesPaths = trusted.Split(Path.PathSeparator);

            // Todo: Look up exe references

            string[]? neededAssemblies = new[]
            {
                "System.Private.CoreLib",
                "System.Runtime",
                "System.Console",
                "System",
                "netstandard",
                "mscorlib",
                "System.Runtime",
            };
            IEnumerable<PortableExecutableReference>? references = trustedAssembliesPaths
                .Where(p => neededAssemblies.Contains(Path.GetFileNameWithoutExtension(p)))
                .Select(p => MetadataReference.CreateFromFile(p));

            foreach (PortableExecutableReference? reference in references)
            {
                _references.Add(reference);
            }
        }

        private void AddTypeReference<TType>()
        {
            string location = typeof(TType).GetTypeInfo().Assembly.Location;
            _references.Add(MetadataReference.CreateFromFile(location));
        }


        public Compiler()
        {
            _references = new HashSet<PortableExecutableReference>();
            ReferenceDotnet();
            AddTypeReference<BrainFuckException>();
            _compilerOptions = new CSharpCompilationOptions(OutputKind.ConsoleApplication)
                .WithPlatform(Platform.AnyCpu)
                .WithOptimizationLevel(OptimizationLevel.Release);
        }

        private IEnumerable<SyntaxTree> CreateSyntaxTees(IList<IInstruction> instructions)
        {
            string bfCode = CodeGenerator.Generate(instructions, "BrainFuckProgram", "BfCode");

            yield return SyntaxFactory.ParseSyntaxTree(bfCode, CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.Latest));
            yield return SyntaxFactory.ParseSyntaxTree("using BrainFuckProgram\r\n;var p = new BfCode();\r\np.RunBrainFuck();", CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.Latest));
        }

        public void Compile(IList<IInstruction> instructions, string file)
        {
            CSharpCompilation compiler = CSharpCompilation.Create("file")
                .WithOptions(_compilerOptions)
                .AddReferences(_references.ToArray())
                .AddSyntaxTrees(CreateSyntaxTees(instructions));

            using (var target = File.Create(file))
            {
                EmitResult emitResult = compiler.Emit(target);
                if (!emitResult.Success)
                {
                    string details = string.Join('\n', emitResult.Diagnostics);
                    Console.WriteLine(details);
                }
            }
        }
    }
}
