#pragma checksum "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0bb4489e1e2ec5d801b80b8c3718cb4d73f50621"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Dashboard_Index), @"mvc.1.0.view", @"/Areas/Manage/Views/Dashboard/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bb4489e1e2ec5d801b80b8c3718cb4d73f50621", @"/Areas/Manage/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eef58f885b7ce15840b5282a509eab1836ccb6a0", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Areas\Manage\Views\Dashboard\Index.cshtml"
  
    ViewBag.Title = "Marketo | Admin Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<main id=\"main\" class=\"main\">\r\n\r\n    <div class=\"pagetitle\">\r\n        <h1>Dashboard</h1>\r\n        <nav>\r\n            <ol class=\"breadcrumb\">\r\n                <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0bb4489e1e2ec5d801b80b8c3718cb4d73f506214081", async() => {
                WriteLiteral("Home");
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
            WriteLiteral(@"</li>
                <li class=""breadcrumb-item active"">Dashboard</li>
            </ol>
        </nav>
    </div><!-- End Page Title -->

    <section class=""section dashboard"">
        <div class=""row"">

            <!-- Left side columns -->
            <div class=""col-lg-8"">
                <div class=""row"">

                    <!-- Date -->
                    <div class=""col-xxl-6 col-md-6"">

                        <div class=""card info-card sales-card"">

                            <div class=""card-body"">
                                <h5 class=""card-title"">Date</h5>

                                <div class=""d-flex align-items-center"">
                                    <div class=""card-icon rounded-circle d-flex align-items-center justify-content-center"">
                                        <i class=""bi bi-calendar2-event""></i>
                                    </div>
                                    <div class=""ps-3"">
                                       ");
            WriteLiteral(@" <h6 id=""today""></h6>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <script>
                            function checkTime(i) {
                                if (i < 10) {
                                    i = ""0"" + i;
                                }
                                return i;
                            }

                            function showDate() {
                                var date = new Date();

                                var day = date.getDate(); // 0-31
                                var month = date.getMonth() + 1; // 0-12
                                var year = date.getFullYear();

                                day = checkTime(day);
                                month = checkTime(month);

                                var today = day + ""."" + month + ""."" + year;
                                document.");
            WriteLiteral(@"getElementById(""today"").innerText = today;
                                document.getElementById(""today"").textContent = today;

                                setTimeout(showDate, 1000);
                            }

                            showDate();
                        </script>

                    </div>
                    <!-- End Date Card -->
                    <!-- Time -->
                    <div class=""col-xxl-6 col-md-6"">

                        <div class=""card info-card sales-card"">

                            <div class=""card-body"">
                                <h5 class=""card-title"">Time</h5>

                                <div class=""d-flex align-items-center"">
                                    <div class=""card-icon rounded-circle d-flex align-items-center justify-content-center"">
                                        <i class=""bi bi-clock""></i>
                                    </div>
                                    <div class=""ps-3"">
 ");
            WriteLiteral(@"                                       <h6 id=""time""></h6>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <script>
                            function checkTime(i) {
                                if (i < 10) {
                                    i = ""0"" + i;
                                }
                                return i;
                            }

                            function showTime() {
                                var date = new Date();

                                var hour = date.getHours(); // 0 - 23
                                var minute = date.getMinutes(); // 0 - 59
                                var second = date.getSeconds(); // 0 - 59

                                hour = checkTime(hour);
                                minute = checkTime(minute);
                                second = checkTime(second);

");
            WriteLiteral(@"                                var time = hour + "":"" + minute + "":"" + second;
                                document.getElementById(""time"").innerText = time;
                                document.getElementById(""time"").textContent = time;

                                setTimeout(showTime, 1000);
                            }

                            showTime();
                        </script>

                    </div>
                    <!-- End Time Card -->
                    <!-- Sales Card -->
                    <div class=""col-xxl-4 col-md-6"">
                        <div class=""card info-card sales-card"">

                            <div class=""card-body"">
                                <h5 class=""card-title"">Sales</h5>

                                <div class=""d-flex align-items-center"">
                                    <div class=""card-icon rounded-circle d-flex align-items-center justify-content-center"">
                                        <i class");
            WriteLiteral(@"=""bi bi-cart""></i>
                                    </div>
                                    <div class=""ps-3"">
                                        <h6>145</h6>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <!-- End Sales Card -->
                    <!-- Revenue Card -->
                    <div class=""col-xxl-4 col-md-6"">
                        <div class=""card info-card revenue-card"">

                            <div class=""card-body"">
                                <h5 class=""card-title"">Revenue</h5>

                                <div class=""d-flex align-items-center"">
                                    <div class=""card-icon rounded-circle d-flex align-items-center justify-content-center"">
                                        <i class=""bi bi-currency-dollar""></i>
                                    </div>
            ");
            WriteLiteral(@"                        <div class=""ps-3"">
                                        <h6>$3,264</h6>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <!-- End Revenue Card -->
                    <!-- Customers Card -->
                    <div class=""col-xxl-4 col-xl-12"">

                        <div class=""card info-card customers-card"">

                            <div class=""card-body"">
                                <h5 class=""card-title"">Customers</h5>

                                <div class=""d-flex align-items-center"">
                                    <div class=""card-icon rounded-circle d-flex align-items-center justify-content-center"">
                                        <i class=""bi bi-people""></i>
                                    </div>
                                    <div class=""ps-3"">
                           ");
            WriteLiteral(@"             <h6>1244</h6>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                    <!-- End Customers Card -->

                </div>
            </div><!-- End Left side columns -->
            <!-- Right side columns -->
            <div class=""col-lg-4"">

                <!-- Website Traffic -->
                <div class=""card"">

                    <div class=""card-body pb-0"">
                        <h5 class=""card-title"">Website Traffic <span>| FlagCounter</span></h5>

                        <div style=""min-height: 500px;"" class=""echart"">
                            <a href=""https://info.flagcounter.com/ydqm"" target=""_blank"" class=""d-block"">
                                <img src=""https://s01.flagcounter.com/count2/ydqm/bg_FFFFFF/txt_000000/border_CCCCCC/columns_3/maxflags_30/viewers_3/labels_1/pageviews_0/flags_0/percent_0/"" alt=""Visito");
            WriteLiteral(@"rs"" width=""100%"">
                            </a>
                            <div class=""d-flex justify-content-between"">
                                <a href=""https://info.flagcounter.com/ydqm"" target=""_blank"" class=""d-block"">
                                    <img src=""https://s11.flagcounter.com/mini/ydqm/bg_FFFFFF/txt_000000/border_CCCCCC/flags_1/"" alt=""Flag Counter"" border=""0"">
                                </a>
                                <a href=""https://info.flagcounter.com/ydqm"" target=""_blank"" class=""d-block"">
                                    <img src=""https://s11.flagcounter.com/mini/ydqm/bg_FFFFFF/txt_000000/border_CCCCCC/flags_0/"" alt=""Flag Counter"" border=""0"">
                                </a>
                            </div>
                        </div>

                    </div>
                </div><!-- End Website Traffic -->

            </div><!-- End Right side columns -->

        </div>
    </section>

</main><!-- End #main -->");
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
