#pragma checksum "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc16749a5771ce82b9534a504e702c0b9e1c023b"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc16749a5771ce82b9534a504e702c0b9e1c023b", @"/Views/FAQ/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_FAQ_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\FAQ\Index.cshtml"
  
    ViewBag.Title = "Marketo | FAQ";

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
            <div class=""col-12 search-section"">
                <h3>Frequently Asked Questions</h3>
                <nav>
                    <ol class=""breadcrumb"">
                        <li class=""breadcrumb-item"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fc16749a5771ce82b9534a504e702c0b9e1c023b4150", async() => {
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
                        <li>
                            <a href=""#1"">
                                <h4>1.</h4>
                                <h5>How does it work?</h5>
                            </a>
                        </li>
                        <li>
                            <a href=""#2"">
                                <h4>2.</h4>
                                <h5>Another very important question in FAQ?</h5>
                            </a>
                        </li>
       ");
            WriteLiteral(@"                 <li>
                            <a href=""#3"">
                                <h4>3.</h4>
                                <h5>Another important quesstion in FAQ?</h5>
                            </a>
                        </li>
                        <li>
                            <a href=""#4"">
                                <h4>4.</h4>
                                <h5>Another question in FAQ?</h5>
                            </a>
                        </li>
                        <li>
                            <a href=""#5"">
                                <h4>5.</h4>
                                <h5>Another very important question in FAQ?</h5>
                            </a>
                        </li>
                        <li>
                            <a href=""#6"">
                                <h4>6.</h4>
                                <h5>Another question in FAQ?</h5>
                            </a>
                        </li>
     ");
            WriteLiteral(@"               </ul>
                </div>
            </div>
            <div class=""col-lg-7 col-md-8"">
                <div class=""faq-heading"" id=""1"">
                    <i data-feather=""help-circle"" class=""theme-color""></i>
                    <div class=""faq-option"">
                        <h3>How does it work?</h3>
                        <h6 class=""font-light"">
                            When choosing a static caravan you will probably look for the holiday
                            park which meets
                            your requirements and the move onto the caravan selection the right holiday park is
                            vital to ensure a long term ownership.
                        </h6>
                    </div>
                </div>

                <div class=""faq-heading"" id=""2"">
                    <i data-feather=""help-circle"" class=""theme-color""></i>
                    <div class=""faq-option"">
                        <h3>Another very important questi");
            WriteLiteral(@"on in FAQ?</h3>
                        <h6 class=""font-light"">
                            Now for yhe caravan and looking for the right caravan to suit your
                            needs. Most of the
                            parks will deal with majority of the manufactures. If buying directly from the park you
                            will probably deal with a salesperson instead of direct with the manufactures. You Can
                            collect brochures direct from the manufactures. you can collect brochures direct from
                            the manufactures to research all the models and specifications which will not only
                            ensure you choose the correct model but also help you to understand what to look for and
                            choice of different modals. To see the caravan you can vixit them at key caravan
                            exhibitions as most top manufactures will display there, see events.
                        </h6");
            WriteLiteral(@">
                    </div>
                </div>

                <div class=""faq-heading"" id=""3"">
                    <i data-feather=""help-circle"" class=""theme-color""></i>
                    <div class=""faq-option"">
                        <h3>Another important quesstion in FAQ?</h3>
                        <h6 class=""font-light"">
                            The static holiday caravan has been designed for holiday use instead
                            of full time
                            living. With its modern construction and use of high quality materials the static
                            caravan should be built to British and European standard: BS EN 1647 but some luxury
                            caravans are built to BS 3632 confirming to residential standards.
                        </h6>
                    </div>
                </div>

                <div class=""faq-heading"" id=""4"">
                    <i data-feather=""help-circle"" class=""theme-color""></i>
    ");
            WriteLiteral(@"                <div class=""faq-option"">
                        <h3>Another question in FAQ?</h3>
                        <h6 class=""font-light"">
                            Normal static caravan can come in either one or two sectiond with
                            width up to 22ft and
                            60ft long. If you have a one piece model this is a single unit and the two piece is
                            known as a twin and usually assembled on site.
                        </h6>
                    </div>
                </div>

                <div class=""faq-heading"" id=""5"">
                    <i data-feather=""help-circle"" class=""theme-color""></i>
                    <div class=""faq-option"">
                        <h3>Another very important question in FAQ?</h3>
                        <h6 class=""font-light"">
                            Decide on how many bedrooms you require as most caravans can be from
                            2 to 4 bedrooms but
             ");
            WriteLiteral(@"               up to eight berths. manufactures will normally have their own layout but will offer but
                            will a number of ranges depending on your budget.
                        </h6>
                    </div>
                </div>

                <div class=""faq-heading"" id=""6"">
                    <i data-feather=""help-circle"" class=""theme-color""></i>
                    <div class=""faq-option"">
                        <h3>Another question in FAQ?</h3>
                        <h6 class=""font-light"">
                            The static holiday caravan has been designed for holiday use instead
                            of full time
                            living. With its modern construction and use of high quality materials the static
                            caravan should be built to British and European standard: BS EN 1647 but some luxury
                            caravans are built to BS 3632 confirming to residential standards.
               ");
            WriteLiteral("         </h6>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<!-- FAQ details end -->\r\n");
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
