using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using System.ComponentModel.DataAnnotations;

namespace AnonDiscord.Models {
    public record MessageEmbed {
        [JsonPropertyName("author")]
        public EmbedAuthor Author {get; init;}
        #nullable enable
        [JsonPropertyName("title")]
        public string? Title {get; init;}
        #nullable disable
        [JsonPropertyName("description")]
        public string Description {get; init;}
        [JsonPropertyName("url")]
        public string Url {get; init;}
        [JsonPropertyName("fields")]
        public IReadOnlyList<MessageEmbedField> Fields {get; init;}
    }

    public record MessageEmbedField {
        [JsonPropertyName("name")]
        public string Name {get; init;}
        [JsonPropertyName("value")]
        public string Value {get; init;}
        [JsonPropertyName("inline")]
        public bool Inline {get; init;}
    }
}