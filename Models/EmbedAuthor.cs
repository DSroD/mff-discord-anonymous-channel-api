using System.Text.Json.Serialization;

namespace AnonDiscord.Models {
    public record EmbedAuthor {
        [JsonPropertyName("name")]
        public string Name {get; init;}
        [JsonPropertyName("url")]
        public string Url {get; init;}
        [JsonPropertyName("icon_url")]
        public string IconUrl {get; init;}
    }
}