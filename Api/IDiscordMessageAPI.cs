using System.Threading.Tasks;
using Refit;

using AnonDiscord.Api.Responses;
using AnonDiscord.Models;

namespace AnonDiscord.Api{

    public interface IDiscordMessageApi {
        [Headers("Content-Type: application/json")]
        [Post("/{id}/{token}")]
        public Task PostMessageAsync(string id, string token, [Body] AnonymousDiscordMessage message);
    }
}