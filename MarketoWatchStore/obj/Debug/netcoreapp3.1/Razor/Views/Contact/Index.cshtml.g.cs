#pragma checksum "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fff7ebd75d621e3dae2bcb10bf3a1249c3d9deb9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fff7ebd75d621e3dae2bcb10bf3a1249c3d9deb9", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7a921d3e41219aae199cad09ee3084e90fd730c", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Contact\Index.cshtml"
  
    ViewBag.Title = "Marketo | Contact";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Breadcrumb section start -->
<section class=""breadcrumb-section section-b-space"">
    <ul class=""circles"">
        <li></li>
        <li></li>
        <li></li>
        <li></li>
        <li></li>
        <li></li>
        <li></li>
        <li></li>
        <li></li>
        <li></li>
    </ul>
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12"">
                <h3>Contact us</h3>
                <nav>
                    <ol class=""breadcrumb"">
                        <li class=""breadcrumb-item"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fff7ebd75d621e3dae2bcb10bf3a1249c3d9deb94762", async() => {
                WriteLiteral("\r\n                                <i class=\"fas fa-home\"></i>\r\n                            ");
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
                        <li class=""breadcrumb-item active"" aria-current=""page"">Contact</li>
                    </ol>
                </nav>
            </div>
        </div>
    </div>
</section>
<!-- Breadcrumb section end -->

<!-- Contact Section Start -->
<section class=""contact-section"">
    <div class=""container"">
        <div class=""row g-4"">
            <div class=""col-lg-7"">
                <div class=""materialContainer"">
                    <div class=""material-details"">
                        <div class=""title title1 title-effect mb-1 title-left"">
                            <h2>Contact Us</h2>
                            <p class=""ms-0 w-100"">
                                Your email address will not be published. Required fields are
                                marked *
                            </p>
                        </div>
                    </div>
                    <div class=""row g-4 mt-md-1 mt-2"">
                   ");
            WriteLiteral(@"     <div class=""col-md-6"">
                            <label for=""first"" class=""form-label"">First Name</label>
                            <input type=""text"" class=""form-control"" id=""first"" placeholder=""Enter Your First Name""
                                   required>
                        </div>
                        <div class=""col-md-6"">
                            <label for=""last"" class=""form-label"">Last Name</label>
                            <input type=""text"" class=""form-control"" id=""last"" placeholder=""Enter Your Last Name""
                                   required>
                        </div>

                        <div class=""col-md-12"">
                            <label for=""email"" class=""form-label"">Email</label>
                            <input type=""email"" class=""form-control"" id=""email""
                                   placeholder=""Enter Your Email Address"" required>
                        </div>

                        <div class=""col-12"">
             ");
            WriteLiteral(@"               <label for=""comment"" class=""form-label"">Comment</label>
                            <textarea class=""form-control"" id=""comment"" rows=""5"" required></textarea>
                        </div>

                        <div class=""col-auto"">
                            <button class=""btn btn-solid-default"" type=""submit"">Submit</button>
                        </div>
                    </div>
                </div>
            </div>

            <div class=""col-lg-5"">
                <div class=""contact-details"">
                    <div>
                        <h2>Let's get in touch</h2>
                        <h5 class=""font-light"">We're open for any suggestion or just to have a chat</h5>
                        <div class=""contact-box"">
                            <div class=""contact-icon"">
                                <i data-feather=""map-pin""></i>
                            </div>
                            <div class=""contact-title"">
                               ");
            WriteLiteral(@" <h4>Address</h4>
                                <p>1418 Riverwood Drive, Suite 3245 Cottonwood, CA 96052, United States</p>
                            </div>
                        </div>

                        <div class=""contact-box"">
                            <div class=""contact-icon"">
                                <i data-feather=""phone""></i>
                            </div>
                            <div class=""contact-title"">
                                <h4>Phone Number</h4>
                                <p>+ 185659635</p>
                                <p>+ 658651167</p>
                            </div>
                        </div>

                        <div class=""contact-box"">
                            <div class=""contact-icon"">
                                <i data-feather=""mail""></i>
                            </div>
                            <div class=""contact-title"">
                                <h4>Email Address</h4>
                  ");
            WriteLiteral(@"              <p>admin@marketo.com</p>
                                <p>marketo@gmail.com</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Contact Section End -->

<!-- Map Section start -->
<section class=""contact-section"">
    <div class=""container-fluid"">
        <div class=""row gy-4"">
            <div class=""col-12 p-0"">
                <div class=""location-map"">
                    <iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3039.428537628781!2d49.84943082770973!3d40.37719391338368!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d077c61fef3%3A0xfa4594c97092ca01!2sAF%20Business%20House!5e0!3m2!1sen!2s!4v1654960225063!5m2!1sen!2s""
                            width=""600"" height=""450"" style=""border:0;""");
            BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 5776, "\"", 5794, 0);
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\"\r\n                            referrerpolicy=\"no-referrer-when-downgrade\"></iframe>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<!-- Map Section End -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
