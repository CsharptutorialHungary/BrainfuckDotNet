//TODO: https://docs.microsoft.com/en-us/dotnet/standard/commandline/
using BrainFuckDotNet;
using BrainFuckDotNet.Parsing;

if (args.Length != 2)
{
    Console.WriteLine("Usage: BrainFuckDotNet input.bf out.exe");
    return;
}

if (!File.Exists(args[0]))
{
    Console.WriteLine($"Input file {args[0]} doesn't exist");
    return;
}

try
{
    string brainFuckCode = File.ReadAllText(args[0]);
    var brainFuckTokens = Tokenizer.Tokenize(brainFuckCode);

    Compiler compiler = new Compiler();
    compiler.Compile(brainFuckTokens, args[1]);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}