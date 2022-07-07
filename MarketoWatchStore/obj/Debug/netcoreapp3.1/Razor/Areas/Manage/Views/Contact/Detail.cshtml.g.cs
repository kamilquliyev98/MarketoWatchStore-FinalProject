#pragma checksum "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Contact\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8ef0c33e68899e24bdc7812cafd9988ac185b25"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Contact_Detail), @"mvc.1.0.view", @"/Areas/Manage/Views/Contact/Detail.cshtml")]
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
#line 2 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\_ViewImports.cshtml"
using MarketoWatchStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\_ViewImports.cshtml"
using MarketoWatchStore.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\_ViewImports.cshtml"
using MarketoWatchStore.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8ef0c33e68899e24bdc7812cafd9988ac185b25", @"/Areas/Manage/Views/Contact/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7abd55dfff91bdf50f9466219838e628249f255e", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Contact_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Contact>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "manage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Contact\Detail.cshtml"
  
    string sender = Model.FirstName + " " + Model.LastName;
    ViewData["Title"] = "Message from " + sender;
    string controller = this.ViewContext.RouteData.Values["controller"].ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<main id=\"main\" class=\"main\">\n\n    <div class=\"pagetitle\">\n        <h1>Contacts</h1>\n        <nav>\n            <ol class=\"breadcrumb\">\n                <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8ef0c33e68899e24bdc7812cafd9988ac185b255289", async() => {
                WriteLiteral("Dashboard");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\n                <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8ef0c33e68899e24bdc7812cafd9988ac185b256902", async() => {
                WriteLiteral("Contacts");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 15 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Contact\Detail.cshtml"
                                                                     WriteLiteral(controller);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-controller", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                <li class=""breadcrumb-item active"">Detail</li>
            </ol>
        </nav>
    </div>
    <!-- End Page Title -->

    <section class=""section profile"">
        <div class=""row"">

            <div class=""col-xl-12"">

                <div class=""card"">
                    <div class=""card-body pt-3"">
                        <!-- Bordered Tabs -->
                        <ul class=""nav nav-tabs nav-tabs-bordered"">

                            <li class=""nav-item"">
                                <button class=""nav-link active"" data-bs-toggle=""tab"" data-bs-target=""#overview"">Overview</button>
                            </li>

                            <li class=""nav-item"">
                                <button class=""nav-link"" data-bs-toggle=""tab"" data-bs-target=""#content"">Content</button>
                            </li>

                        </ul>
                        <div class=""tab-content pt-2"">

                            <div class=""tab-pane fade show active profile");
            WriteLiteral(@"-overview"" id=""overview"">

                                <h5 class=""card-title""></h5>

                                <div class=""row"">
                                    <div class=""col-lg-3 col-md-4 label"">First name:</div>
                                    <div class=""col-lg-9 col-md-8"">");
#nullable restore
#line 49 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Contact\Detail.cshtml"
                                                              Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                                </div>\n\n                                <div class=\"row\">\n                                    <div class=\"col-lg-3 col-md-4 label\">Last name:</div>\n                                    <div class=\"col-lg-9 col-md-8\">");
#nullable restore
#line 54 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Contact\Detail.cshtml"
                                                              Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                                </div>\n\n                                <div class=\"row\">\n                                    <div class=\"col-lg-3 col-md-4 label\">Email:</div>\n                                    <div class=\"col-lg-9 col-md-8\">");
#nullable restore
#line 59 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Contact\Detail.cshtml"
                                                              Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                                </div>\n\n                                <div class=\"row\">\n                                    <div class=\"col-lg-3 col-md-4 label \">Date:</div>\n                                    <div class=\"col-lg-9 col-md-8\">");
#nullable restore
#line 64 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Contact\Detail.cshtml"
                                                              Write(Model.CreatedAt?.ToString("g"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                                </div>\n\n");
#nullable restore
#line 67 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Contact\Detail.cshtml"
                                 if (Model.IsDeleted)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"row\">\n                                        <div class=\"col-lg-3 col-md-4 label\">Deleted at:</div>\n                                        <div class=\"col-lg-9 col-md-8\">");
#nullable restore
#line 71 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Contact\Detail.cshtml"
                                                                  Write(Model.DeletedAt?.ToString("g"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                                    </div>\n");
#nullable restore
#line 73 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Contact\Detail.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            </div>\n\n                            <div class=\"tab-pane fade profile-edit pt-3\" id=\"content\">\n\n                                <h5 class=\"card-title\">Message</h5>\n                                <p>");
#nullable restore
#line 80 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Contact\Detail.cshtml"
                              Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

                            </div>

                        </div>
                        <!-- End Bordered Tabs -->

                    </div>
                </div>

            </div>

            <div class=""col-xl-12 d-grid mt-3"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8ef0c33e68899e24bdc7812cafd9988ac185b2514391", async() => {
                WriteLiteral("Go back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 93 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Contact\Detail.cshtml"
                                         WriteLiteral(controller);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-controller", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-status", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 93 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Contact\Detail.cshtml"
                                                                                           WriteLiteral(ViewBag.Status);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["status"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-status", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["status"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 93 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Contact\Detail.cshtml"
                                                                                                                            WriteLiteral(ViewBag.CurrentPage);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            </div>\n        </div>\n    </section>\n\n</main>\n<!-- End #main -->\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Contact> Html { get; private set; }
    }
}
#pragma warning restore 1591
