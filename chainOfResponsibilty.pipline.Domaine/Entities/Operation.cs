

using System.Reflection.PortableExecutable;
using System.Text.Json.Serialization;

namespace chainOfResponsibilty.pipline.Domaine.Entities;

    public class Operation
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("type")]
        public required  string Type { get; set; }
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }
        [JsonPropertyName("machine")]
        public required  Machine Machine { get; set; }
    }

