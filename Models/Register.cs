using System.Text.Json.Serialization;

namespace MODULE5HW1.Models
{
    public class Register
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}