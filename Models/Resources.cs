using System.Text.Json.Serialization;

namespace MODULE5HW1.Models
{
    public class Resources
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("pantone_value")]
        public string Pantone_Color { get; set; }
    }
}