#pragma checksum "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74de0fb7126b7775d941a4f90587421736ea993d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FAQ_Index), @"mvc.1.0.view", @"/Views/FAQ/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\_ViewImports.cshtml"
using MarketoWatchStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\_ViewImports.cshtml"
using MarketoWatchStore.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\_ViewImports.cshtml"
using MarketoWatchStore.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74de0fb7126b7775d941a4f90587421736ea993d", @"/Views/FAQ/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc9b8db58987dd5d0781cf5d129fe47081a577f6", @"/Views/_ViewImports.cshtml")]
    public class Views_FAQ_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FAQVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml"
  
    ViewBag.Title = "Marketo | FAQ";
    int questionId = 0;
    int answerId = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<!-- Breadcrumb section start -->\n<section class=\"breadcrumb-section section-b-space\">\n    <ul class=\"circles\">\n");
#nullable restore
#line 11 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml"
         for (int i = 1; i <= 10; i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li></li>\n");
#nullable restore
#line 14 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </ul>
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12 search-section"">
                <h3>Frequently Asked Questions</h3>
                <nav>
                    <ol class=""breadcrumb"">
                        <li class=""breadcrumb-item"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74de0fb7126b7775d941a4f90587421736ea993d5089", async() => {
                WriteLiteral("\n                                <i class=\"fas fa-home\"></i>\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </li>
                        <li class=""breadcrumb-item active"" aria-current=""page"">FAQ</li>
                    </ol>
                </nav>
            </div>
        </div>
    </div>
</section>
<!-- Breadcrumb section end -->

<!-- FAQ details start -->
<section class=""faq-details section-b-space"">
    <div class=""container"">
        <div class=""row g-4"">
            <div class=""col-md-4"">
                <div class=""faq-link-box"">
                    <ul>
");
#nullable restore
#line 43 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml"
                         foreach (FAQ faq in Model.FAQs)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>\n                                <a");
            BeginWriteAttribute("href", " href=\"", 1384, "\"", 1407, 2);
            WriteAttributeValue("", 1391, "#", 1391, 1, true);
#nullable restore
#line 46 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml"
WriteAttributeValue("", 1392, ++questionId, 1392, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                    <h4>");
#nullable restore
#line 47 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml"
                                    Write(questionId);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</h4>\n                                    <h5>");
#nullable restore
#line 48 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml"
                                   Write(faq.Question);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                                </a>\n                            </li>\n");
#nullable restore
#line 51 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\n                </div>\n            </div>\n            <div class=\"col-lg-7 col-md-8\">\n\n");
#nullable restore
#line 57 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml"
                 foreach (FAQ faq in Model.FAQs)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"faq-heading\"");
            BeginWriteAttribute("id", " id=\"", 1850, "\"", 1868, 1);
#nullable restore
#line 59 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml"
WriteAttributeValue("", 1855, ++answerId, 1855, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <i data-feather=\"help-circle\" class=\"theme-color\"></i>\n                        <div class=\"faq-option\">\n                            <h3>");
#nullable restore
#line 62 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml"
                           Write(faq.Question);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n                            <h6 class=\"font-light\">");
#nullable restore
#line 63 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml"
                                              Write(faq.Answer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\n                        </div>\n                    </div>\n");
#nullable restore
#line 66 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n    </div>\n</section>\n<!-- FAQ details end -->\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FAQVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
