//TODO: https://docs.microsoft.com/en-us/dotnet/standard/commandline/

//BrainFuckDotNet compile input.txt out.exe
//BrainFuckDotNet run input.txt

//MMP+
//BrainFuckDotNet generate input.txt -> input.cs

using BrainFuckDotNet;
using BrainFuckDotNet.Parsing;
using BrainFuckDotnet.Runtime;

using System.CommandLine;

var root = new RootCommand("Brainfuck interpreter/compiler");

var compileCommand = new Command("compile", "Compile a brainfuck source code to .NET Assembly");
var compileInputOption = new Option<string>("--input", "input brainfuck file");
var outputOption = new Option<string>("--output", "output .net assembly");
compileInputOption.IsRequired = true;
outputOption.IsRequired = true;

compileCommand.Add(compileInputOption);
compileCommand.Add(outputOption);


var runCommand = new Command("run", "Run a brainfuck source code in interpreter mode");
var runInputOption = new Option<string>("--input", "input brainfuck file");
runInputOption.IsRequired = true;

runCommand.Add(runInputOption);

compileCommand.SetHandler(OnCompile, compileInputOption, outputOption);
runCommand.SetHandler(OnRun, runInputOption);

root.Add(compileCommand);
root.Add(runCommand);

root.Invoke(args);

void OnCompile(string input, string output)
{
    if (!File.Exists(input))
    {
        Console.Error.WriteLine($"File doesn't exist: {input}");
        return;
    }

    try
    {
        string brainFuckCode = File.ReadAllText(input);
        var brainFuckTokens = Tokenizer.Tokenize(brainFuckCode);

        var compiler = new Compiler();
        compiler.Compile(brainFuckTokens, output);
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine(ex.Message);
    }

}

void OnRun(string input)
{
    if (!File.Exists(input))
    {
        Console.Error.WriteLine($"File doesn't exist: {input}");
        return;
    }

    try
    {
        var console = new SystemConsole();
        var interpreter = new Interpreter(console);

        interpreter.Execute(File.ReadAllText(input));
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine(ex.Message);
    }
}
