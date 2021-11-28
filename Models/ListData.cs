using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MODULE5HW1.Models
{
    public class ListData<TData>
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("data")]
        public List<TData> Data { get; set; }

        [JsonPropertyName("support")]
        public Support Support { get; set; }
    }
}