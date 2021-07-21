**MFF Discord Anonymous Channel Gate**

OpenAPI for posting to MFF Discord anonymous channel.
This API is created in order to limit possible harmful messages that could be send
using full power of discord webhook. Instead, this API allows only limited content to be send.

**Deployment**

- API configuration consists only of typing webhook ID and token into webhook.json (for now).
- Run *dotnet run*
- SwaggerUI is availible at `/swagger`
- API endpoint is `POST /message`

**TODO**

- Request body documentation
- JSON response consiting of message and channel id. *This can be used for editing the message in the future.*