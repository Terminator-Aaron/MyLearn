﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConfigurationOptionsTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((builderContext, config) =>
           {
               config.SetBasePath(Directory.GetCurrentDirectory());
               config.AddJsonFile("section.json", optional: true, reloadOnChange: true);
               config.AddJsonFile("starship.json", optional: true, reloadOnChange: true);
               config.AddJsonFile("options.json", optional: true, reloadOnChange: true);
               config.AddEnvironmentVariables("ASPNETCORE_");

           })
                .UseStartup<StartupDevelopment>();
    }
}
