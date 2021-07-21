using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using Refit;

using AnonDiscord.Api;

namespace AnonDiscord
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var webhookSettings = new ConfigurationBuilder()
                .AddJsonFile("webhook.json", false)
                .Build();

            services.AddControllers();
            services.AddSingleton<IConfiguration>(webhookSettings);
            services.AddRefitClient<IDiscordMessageApi>()
                .ConfigureHttpClient(client => {
                    client.BaseAddress = new Uri("https://discord.com/api/webhooks");
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "MFF Discord Anonymous Channel",
                    Version = "v1",
                    Description = "API for sending anonymous messages to MFF Discord (fully-anonymous-channel)",
                    Contact = new OpenApiContact{
                        Name = "Daniel Rod",
                        Email = "rodd@lab.ms.mff.cuni.cz",
                        Url = new Uri("https://github.com/dsrod"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "mff_discord_anonymous_channel v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
