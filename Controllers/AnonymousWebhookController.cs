using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using Refit;

using AnonDiscord.Api;
using AnonDiscord.Models;

namespace AnonDiscord.Controllers
{
    [ApiController]
    [Route("message")]
    public class AnonymousWebhookController : ControllerBase {

        private IDiscordMessageApi _messageApi;
        private readonly string _id;
        private readonly string _token;
        private readonly ILogger _logger;

        public AnonymousWebhookController(IDiscordMessageApi messageApi, IConfiguration apiConfig, ILogger<AnonymousWebhookController> logger){
            _messageApi = messageApi;
            _id = apiConfig["id"];
            _token = apiConfig["token"];
            _logger = logger;

        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync(AnonymousDiscordMessage message) {
            try {
                await _messageApi.PostMessageAsync(_id, _token, message);
                return StatusCode(200);
            } catch (ApiException e) {
                _logger.LogError(e.Message);
                var content = await e.GetContentAsAsync<string>();
                _logger.LogError(content);
                return StatusCode(400);
            }
            
        }
    }
}