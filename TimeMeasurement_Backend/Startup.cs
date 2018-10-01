﻿using System.Net.WebSockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeMeasurement_Backend.Handlers;

namespace TimeMeasurement_Backend
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            //Register Custom Connection Handling
            app.Use(async (context, next) =>
            {
                //Get request path
                var path = context.Request.Path.Value.Split('/');
                //Check if request is WS and path requestPath has value
                if (context.WebSockets.IsWebSocketRequest && path.Length == 2)
                {
                    //admin / station / viewer
                    string requestPath = path[1].ToLower();
                    //get connected websocket
                    var ws = await context.WebSockets.AcceptWebSocketAsync();
                    switch (requestPath) {
                        case "admin": {
                            break;
                        }
                        case "station":
                            await StationHandler.Instance.SetStation(ws);
                            break;
                        case "viewer":
                            break;
                    }
                }
                else
                {
                    //Pass to next handler (registered by ASP)
                    await next.Invoke();
                }
            });

            app.UseMvc();
        }
    }
}
