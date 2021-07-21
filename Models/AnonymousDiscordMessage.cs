using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnonDiscord.Models
{
    public record AnonymousDiscordMessage {
        #nullable enable
        [JsonPropertyName("username")]
        public string? Username {get; init;}
        #nullable disable
        
        [JsonPropertyName("content")]
        [Required]
        public string Content {get; init;}
        
        #nullable enable
        [JsonPropertyName("embeds")]
        [DefaultValue(null)]
        public IReadOnlyList<MessageEmbed>? Embeds {get; init;}
        #nullable disable
    }
}