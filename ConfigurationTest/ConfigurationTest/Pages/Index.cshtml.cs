using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ConfigurationOptionsTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;

        public IndexModel(IConfiguration config)
        {
            _config = config;
        }

        public int NumberConfig { get; private set; }
        public string StringConfig { get; private set; }

        public string EnviromentConfig { get; private set; }


        public IConfigurationSection ConfigSection { get; private set; }

        public Starship Starship { get; private set; }

        public void OnGet()
        {
            NumberConfig = _config.GetValue<int>("NumberKey", 99);
            StringConfig = _config.GetValue<string>("AllowedHosts");//_config.GetValue<string>("section2:subsection0:key0");

            EnviromentConfig = _config.GetValue<string>("MyDotnetCoreTest");

            

            ConfigSection = _config.GetSection("section2:subsection0");

            var starship = new Starship();
            _config.GetSection("starship").Bind(starship);
            Starship = starship;

        }
    }
}
