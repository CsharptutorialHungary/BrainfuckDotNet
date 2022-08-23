using System.Text.Json.Serialization;

namespace BrainFuckDotNet.Domain
{
    public class RuntimeConfig
    {

        [JsonPropertyName("runtimeOptions")]
        public Runtimeoptions RuntimeOptions { get; set; }

        public RuntimeConfig()
        {
            RuntimeOptions = new();
        }
    }
}