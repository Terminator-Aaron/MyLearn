#pragma checksum "G:\MyLearn2\Dotnet\ConfigurationTest\ConfigurationTest\Pages\Options\Accessor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5786b51d8a2b07028eb466449e786dc39ce3c9b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ConfigurationOptionsTest.Pages.Options.Pages_Options_Accessor), @"mvc.1.0.razor-page", @"/Pages/Options/Accessor.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Options/Accessor.cshtml", typeof(ConfigurationOptionsTest.Pages.Options.Pages_Options_Accessor), null)]
namespace ConfigurationOptionsTest.Pages.Options
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "G:\MyLearn2\Dotnet\ConfigurationTest\ConfigurationTest\Pages\_ViewImports.cshtml"
using ConfigurationOptionsTest;

#line default
#line hidden
#line 3 "G:\MyLearn2\Dotnet\ConfigurationTest\ConfigurationTest\Pages\Options\Accessor.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5786b51d8a2b07028eb466449e786dc39ce3c9b3", @"/Pages/Options/Accessor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbd33587bbf9c0b8f554d16584ba24bbddb1467a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Options_Accessor : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(222, 5, true);
            WriteLiteral("\r\n<p>");
            EndContext();
            BeginContext(228, 21, false);
#line 9 "G:\MyLearn2\Dotnet\ConfigurationTest\ConfigurationTest\Pages\Options\Accessor.cshtml"
Write(Model.Options.Option1);

#line default
#line hidden
            EndContext();
            BeginContext(249, 9, true);
            WriteLiteral("</p>\r\n<p>");
            EndContext();
            BeginContext(259, 21, false);
#line 10 "G:\MyLearn2\Dotnet\ConfigurationTest\ConfigurationTest\Pages\Options\Accessor.cshtml"
Write(Model.Options.Option2);

#line default
#line hidden
            EndContext();
            BeginContext(280, 19, true);
            WriteLiteral("</p>\r\n<hr />\r\n\r\n<p>");
            EndContext();
            BeginContext(300, 36, false);
#line 13 "G:\MyLearn2\Dotnet\ConfigurationTest\ConfigurationTest\Pages\Options\Accessor.cshtml"
Write(OptionsAccessor.CurrentValue.Option1);

#line default
#line hidden
            EndContext();
            BeginContext(336, 9, true);
            WriteLiteral("</p>\r\n<p>");
            EndContext();
            BeginContext(346, 36, false);
#line 14 "G:\MyLearn2\Dotnet\ConfigurationTest\ConfigurationTest\Pages\Options\Accessor.cshtml"
Write(OptionsAccessor.CurrentValue.Option2);

#line default
#line hidden
            EndContext();
            BeginContext(382, 19, true);
            WriteLiteral("</p>\r\n<hr />\r\n\r\n<p>");
            EndContext();
            BeginContext(402, 51, false);
#line 17 "G:\MyLearn2\Dotnet\ConfigurationTest\ConfigurationTest\Pages\Options\Accessor.cshtml"
Write(NamedOptionsAccessor.Get("named_options_1").Option1);

#line default
#line hidden
            EndContext();
            BeginContext(453, 4, true);
            WriteLiteral("</p>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IOptionsSnapshot<MyOptions> NamedOptionsAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IOptionsMonitor<MyOptions> OptionsAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ConfigurationOptionsTest.Pages.Options.AccessorModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ConfigurationOptionsTest.Pages.Options.AccessorModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ConfigurationOptionsTest.Pages.Options.AccessorModel>)PageContext?.ViewData;
        public ConfigurationOptionsTest.Pages.Options.AccessorModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
