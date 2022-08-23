using System.Text.Json;

using BrainFuckDotNet.Domain;

namespace BrainFuckDotNet
{
    internal static class RuntimeConfigManager
    {
        private static RuntimeConfig CreateConfig()
        {
            return new RuntimeConfig
            {
                RuntimeOptions = new Runtimeoptions
                {
                    Tfm = "net6.0",
                    Framework = new Framework
                    {
                        Name = "Microsoft.NETCore.App",
                        Version = "6.0.0",
                    }
                }
            };
        }

        public static void CreateConfigJson(string exeName)
        {
            RuntimeConfig toSerialize = CreateConfig();

            string json = JsonSerializer.Serialize(toSerialize, new JsonSerializerOptions
            {
                WriteIndented = true,
            });

            string jsonName = Path.ChangeExtension(exeName, "runtimeconfig.json");
            File.WriteAllText(jsonName, json);
        }
    }
}
