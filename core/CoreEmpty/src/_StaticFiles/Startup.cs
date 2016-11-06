using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;

namespace _StaticFiles
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
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

        public void ConfigureStaticFiles(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            app.UseStaticFiles(); // For the wwwroot folder

            app.UseStaticFiles(new StaticFileOptions() {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"MyStaticFiles")),
                RequestPath = "/MyStaticFilesTest",
            });

            // 浏览目录文件
            app.UseDirectoryBrowser(new DirectoryBrowserOptions() {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"MyStaticFiles")),
                RequestPath = "/MyStaticFilesList",
            });
        }

        public void ConfigureDefaultFiles(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }

        public void ConfigureDefaultFiles2(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            app.UseDefaultFiles(new DefaultFilesOptions() {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html"))
            });
            app.UseStaticFiles(new StaticFileOptions() {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html"))
            });
        }

        public void ConfigureDefaultFiles3(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("myDefault.htm");
            options.DefaultFileNames.Add("myDefault.html");

            app.UseDefaultFiles(options);
        }

        public void ConfigureFileServer(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            app.UseFileServer(new FileServerOptions() {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"MyStaticFiles")),
                RequestPath = "/StaticFile",
                EnableDirectoryBrowsing = true,
            });
        }

        public void ConfigureContentType(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            var typeProvider = new FileExtensionContentTypeProvider();
            typeProvider.Mappings[".html10"] = "text/html";
            typeProvider.Mappings[".image"] = "image/png";
            typeProvider.Mappings.Remove(".mp4");

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"contentType")),
                RequestPath = "/contentType",
                ContentTypeProvider = typeProvider,
            });
        }

        public void ConfigureNoStandarContent(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"contentType")),
                RequestPath= "/NoStandarContent",
                ServeUnknownFileTypes = true,
                DefaultContentType="text/html",
            });
        }
    }
}
