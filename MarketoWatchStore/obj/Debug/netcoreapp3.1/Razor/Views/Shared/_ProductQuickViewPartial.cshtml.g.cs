#pragma checksum "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d2139939a5e31cfd1e4939d6c71357542bc7354"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProductQuickViewPartial), @"mvc.1.0.view", @"/Views/Shared/_ProductQuickViewPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d2139939a5e31cfd1e4939d6c71357542bc7354", @"/Views/Shared/_ProductQuickViewPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7a921d3e41219aae199cad09ee3084e90fd730c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProductQuickViewPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid bg-img blur-up lazyload"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("product"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "shoppingcart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-solid-default btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
    <div class=""modal-body"">
        <div class=""row gy-4"">
            <div class=""col-lg-6"">
                <div class=""quick-view-image"">
                    <div class=""quick-view-slider ratio_2"">
                        <div>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9d2139939a5e31cfd1e4939d6c71357542bc73546267", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 392, "~/assets/images/products/", 392, 25, true);
#nullable restore
#line 10 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
AddHtmlAttributeValue("", 417, Model.MainImage, 417, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 12 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                         foreach (ProductImage productImage in Model.ProductImages)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9d2139939a5e31cfd1e4939d6c71357542bc73548396", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 714, "~/assets/images/products/", 714, 25, true);
#nullable restore
#line 15 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
AddHtmlAttributeValue("", 739, productImage.Image, 739, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n");
#nullable restore
#line 17 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                    <div class=\"quick-nav\">\r\n                        <div>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9d2139939a5e31cfd1e4939d6c71357542bc735410518", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1023, "~/assets/images/products/", 1023, 25, true);
#nullable restore
#line 21 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
AddHtmlAttributeValue("", 1048, Model.MainImage, 1048, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 23 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                         foreach (ProductImage productImage in Model.ProductImages)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9d2139939a5e31cfd1e4939d6c71357542bc735412652", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1345, "~/assets/images/products/", 1345, 25, true);
#nullable restore
#line 26 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
AddHtmlAttributeValue("", 1370, productImage.Image, 1370, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n");
#nullable restore
#line 28 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <div class=\"product-right\">\r\n                    <h2 class=\"mb-2\">");
#nullable restore
#line 34 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                                 Write(Model.Brand.Title + " " + Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                    <ul class=""rating mt-1"">
                        <li>
                            <i class=""fas fa-star theme-color""></i>
                        </li>
                        <li>
                            <i class=""fas fa-star theme-color""></i>
                        </li>
                        <li>
                            <i class=""fas fa-star theme-color""></i>
                        </li>
                        <li>
                            <i class=""fas fa-star""></i>
                        </li>
                        <li>
                            <i class=""fas fa-star""></i>
                        </li>
                        <li class=""font-light"">(");
#nullable restore
#line 51 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                                            Write((Model.Count > 0) ? "In stock" : "Out of stock");

#line default
#line hidden
#nullable disable
            WriteLiteral(")</li>\r\n                    </ul>\r\n                    <div class=\"price mt-3\">\r\n");
#nullable restore
#line 54 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                         if (Model.DiscountPrice != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h3>$");
#nullable restore
#line 56 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                             Write(Model.DiscountPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <s>$");
#nullable restore
#line 56 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                                                        Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</s></h3>\r\n");
#nullable restore
#line 57 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h3>$");
#nullable restore
#line 60 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                             Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 61 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                    <div class=\"color-types\">\r\n                        <h4>Available colors:</h4>\r\n                        <ul class=\"color-variant mb-0\">\r\n");
#nullable restore
#line 66 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                             foreach (ProductColour productColour in Model.ProductColours)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li");
            BeginWriteAttribute("style", " style=\"", 3278, "\"", 3332, 3);
            WriteAttributeValue("", 3286, "background-color:", 3286, 17, true);
#nullable restore
#line 68 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
WriteAttributeValue(" ", 3303, productColour.Colour.Title, 3304, 27, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3331, ";", 3331, 1, true);
            EndWriteAttribute();
            WriteLiteral("></li>\r\n");
#nullable restore
#line 69 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </ul>
                    </div>
                    <div class=""product-details"">
                        <h4>product details</h4>
                        <ul>
                            <li>
                                <span class=""font-light"">Style :</span> Boat Shoe
                            </li>
                            <li>
                                <span class=""font-light"">Catgory :</span> Sports Shoes
                            </li>
                            <li>
                                <span class=""font-light"">Tags:</span> Summer
                            </li>
                        </ul>
                    </div>
                    <div class=""product-btns"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d2139939a5e31cfd1e4939d6c71357542bc735420280", async() => {
                WriteLiteral("Add to cart");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 87 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                                                                              WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d2139939a5e31cfd1e4939d6c71357542bc735422817", async() => {
                WriteLiteral("View details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 88 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\Shared\_ProductQuickViewPartial.cshtml"
                                                                        WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
