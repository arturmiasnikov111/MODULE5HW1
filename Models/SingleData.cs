using System.Text.Json;
using System.Text.Json.Serialization;

namespace MODULE5HW1.Models
{
    public class SingleData<TData>
    {
        [JsonPropertyName("data")]
        public TData Data { get; set; }

        [JsonPropertyName("support")]
        public Support Support { get; set; }
    }
}