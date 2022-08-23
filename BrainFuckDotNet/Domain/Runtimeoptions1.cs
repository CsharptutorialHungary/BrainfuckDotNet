using System.Text.Json.Serialization;

namespace BrainFuckDotNet.Domain
{
    public class Runtimeoptions
    {
        [JsonPropertyName("tfm")]
        public string Tfm { get; set; }

        [JsonPropertyName("framework")]
        public Framework Framework { get; set; }

        public Runtimeoptions()
        {
            Tfm = string.Empty;
            Framework = new Framework();
        }
    }
}