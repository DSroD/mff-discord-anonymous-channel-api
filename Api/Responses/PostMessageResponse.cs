using System.Text.Json.Serialization;

namespace AnonDiscord.Api.Responses {

    public record PostMessageResponse {
        [JsonPropertyName("id")]
        public string Id {get; init;}
        [JsonPropertyName("channel_id")]
        public string ChannelId {get; init;}
    }
}