using System.Text.Json.Serialization;

namespace BrainFuckDotNet.Domain
{
    public class Framework
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        public Framework()
        {
            Name = string.Empty;
            Version = string.Empty;
        }
    }
}