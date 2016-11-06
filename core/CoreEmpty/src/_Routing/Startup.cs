using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;

namespace _Routing
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

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

        public void ConfigureRouting(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var trackPackageRouteHandler = new RouteHandler(async (context) =>
            {
                var routeData = context.GetRouteData();
                var routeValues = routeData.Values;
                var routeTokens = routeData.DataTokens;

                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("Hello! Route Values:" + String.Join(",", routeValues));
                await context.Response.WriteAsync("<hr/>Hello! Route Tokens:" + String.Join(",", routeTokens));
            });

            var routeBuilder = new RouteBuilder(app, trackPackageRouteHandler);

            routeBuilder.MapRoute("Trace Package Route", // route name
                "package/{operation:regex(^track$)}/{id:int}/{age?}/{*any}", // template
                new { age = 20 }, // default value
                new { age = new RegexRouteConstraint("[2-9][0-9]") }, // constraint
                new { locale = "en-US" } // dataToken
            );

            // 只有Get请求
            routeBuilder.MapGet("hello/{name}", async (context) =>
            {
                var name = context.GetRouteValue("name");
                await context.Response.WriteAsync("Hello " + name);
            });

            var routes = routeBuilder.Build();

            app.UseRouter(routes);

            // 生成URL
            app.Run(async (context) =>
            {
                var dictionary = new RouteValueDictionary()
                {
                    { "name","aaron2" }
                };

                var vpc = new VirtualPathContext(context, null, dictionary);
                var path = routes.GetVirtualPath(vpc).VirtualPath;

                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("Menu<hr/>");
                await context.Response.WriteAsync($"<a href='{path}'>Create Package 123</a><br/>");
            });
        }
    }
}
