using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text;

namespace _ErrorHandling
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context)=> {
                if (context.Request.Query.ContainsKey("throw"))
                {
                    throw new Exception("Exception triggered!");
                }

                var builder = new StringBuilder();
                builder.AppendLine("<html><body>Hello World!");
                builder.AppendLine("<ul>");
                builder.AppendLine("<li><a href=\"/?throw=true\">Throw Exception</a></li>");
                builder.AppendLine("<li><a href=\"/missingpage\">Missing Page</a></li>");
                builder.AppendLine("</ul>");
                builder.AppendLine("</body></html>");

                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(builder.ToString());
            });
        }

        public void ConfigureStatusCodePage(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStatusCodePages("text/plain", "Response, status code: {0}");
        }

        public void ConfigureStatusCodeRedirect(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStatusCodePagesWithRedirects("~/errors/{0}");
            //app.UseStatusCodePagesWithReExecute("/errors/{0}");
        }
    }
}
