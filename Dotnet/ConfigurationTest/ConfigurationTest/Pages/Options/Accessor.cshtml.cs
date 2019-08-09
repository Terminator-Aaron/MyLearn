using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace ConfigurationOptionsTest.Pages.Options
{
    public class AccessorModel : PageModel
    {
        public readonly MyOptions Options;

        public AccessorModel(IOptionsMonitor<MyOptions> optionsAccessor)
        {
            Options = optionsAccessor.CurrentValue;
        }

        public void OnGet()
        {
        }
    }
}