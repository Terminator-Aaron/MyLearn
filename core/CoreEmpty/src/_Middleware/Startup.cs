using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace _Middlewave
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        #region == Configure|Run, User, Map, MapWhen ==

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        // Use EnvironmentName = "LogInline"
        public void ConfigureLogInline(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            loggerfactory.AddConsole(minLevel: LogLevel.Information);
            var logger = loggerfactory.CreateLogger(env.EnvironmentName); //EnvironmentName = "LogInline"
            app.Use(async (context, next) =>
            {
                logger.LogInformation("Handling request.");
                await next.Invoke();
                logger.LogInformation("Finished handling request.");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from " + env.EnvironmentName);
            });
        }

        // Map
        public void ConfigureMapTest(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            app.Map("/MapTest", (builder) =>
            {
                builder.Run(async (context) =>
                {
                    // example http://localhost:5000/MapTest/ttt
                    string pathbase = context.Request.PathBase.Value;   // "/MapTest"
                    string path = context.Request.Path.Value;   // "/ttt"
                    await context.Response.WriteAsync(string.Format("This is from MapTest | PathBase={0},Path={1}", pathbase, path));
                });
            });
        }

        // MapWhen
        public void ConfigureMapWhenTest(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            app.MapWhen((context) =>
            {
                return context.Request.Query.ContainsKey("MapWhen");
            }, (builder) =>
            {
                builder.Run(async (context)=> {
                    await context.Response.WriteAsync("This is from MapWhenTest");
                });
            });

            app.Run(async (context) => {
                await context.Response.WriteAsync("This is from other");
            });
        }

        // Map嵌套
        public void ConfigureMapLevel(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            app.Map("/MapL_1", (builder1) =>
            {
                builder1.Map("/MapL_a", (builder2) =>
                {
                    builder2.Run(async (context)=> {
                        await context.Response.WriteAsync("/MapL_1/MapL_a");
                    });
                });

                builder1.Map("/MapLb_a", (builder2) =>
                {
                    builder2.Run(async (context) => {
                        await context.Response.WriteAsync("/MapL_1/MapLb_a");
                    });
                });
            });
        }

        public void ConfigureCustomMiddleware(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            app.UseRequestLoggerMiddleware();
            app.Run(async (context)=>{
                await context.Response.WriteAsync("     这是请求CustomMiddleware        ");
            });
        }

        #endregion

       
    }
}
