#pragma checksum "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\ShoppingCart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b1e469ffc89e7a286dbbfaf4026ea69e579d5ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShoppingCart_Index), @"mvc.1.0.view", @"/Views/ShoppingCart/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b1e469ffc89e7a286dbbfaf4026ea69e579d5ec", @"/Views/ShoppingCart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a726e7f69dcd06b93b9fc1fc595269a54470df9e", @"/Views/_ViewImports.cshtml")]
    public class Views_ShoppingCart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "C:\Users\Kamil\source\repos\MarketoWatchStore\MarketoWatchStore\Views\ShoppingCart\Index.cshtml"
   
    ViewBag.Title = "Marketo | Shopping Cart";

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
                <h3>Shopping Cart</h3>
                <nav>
                    <ol class=""breadcrumb"">
                        <li class=""breadcrumb-item"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b1e469ffc89e7a286dbbfaf4026ea69e579d5ec4597", async() => {
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
                        <li class=""breadcrumb-item active"" aria-current=""page"">Shopping cart</li>
                    </ol>
                </nav>
            </div>
        </div>
    </div>
</section>
<!-- Breadcrumb section end -->
<!-- Cart Section Start -->
<section class=""cart-section section-b-space"">
    <div class=""container"">
        <div class=""row"">

            <div class=""col-sm-12 table-responsive mt-4"">
                <table class=""table cart-table"">
                    <thead>
                        <tr class=""table-head"">
                            <th scope=""col"">image</th>
                            <th scope=""col"">product name</th>
                            <th scope=""col"">price</th>
                            <th scope=""col"">quantity</th>
                            <th scope=""col"">total</th>
                            <th scope=""col"">remove</th>
                        </tr>
                    </thead>
                  ");
            WriteLiteral(@"  <tbody>
                        <tr>
                            <td>
                                <a href=""product-left-sidebar.html"">
                                    <img src=""assets/images/products/1.jpg"" class="" blur-up lazyload"" alt=""product"">
                                </a>
                            </td>
                            <td>
                                <a href=""product-left-sidebar.html"">Yellow Jacket</a>
                                <div class=""mobile-cart-content row"">
                                    <div class=""col"">
                                        <div class=""qty-box"">
                                            <div class=""input-group"">
                                                <input type=""text"" name=""quantity"" class=""form-control input-number""
                                                       value=""1"">
                                            </div>
                                        </div>
                      ");
            WriteLiteral(@"              </div>
                                    <div class=""col"">
                                        <h2>$63.00</h2>
                                    </div>
                                    <div class=""col"">
                                        <h2 class=""td-color"">
                                            <a href=""javascript:void(0)"">
                                                <i class=""fas fa-times""></i>
                                            </a>
                                        </h2>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <h2>$63.00</h2>
                            </td>
                            <td>
                                <div class=""qty-box"">
                                    <div class=""input-group"">
                                        <input type=""number"" name=""quantity"" class=""form-");
            WriteLiteral(@"control input-number""
                                               value=""1"" min=""1"">
                                    </div>
                                </div>
                            </td>
                            <td>
                                <h2 class=""td-color"">$3648.00</h2>
                            </td>
                            <td>
                                <a href=""javascript:void(0)"">
                                    <i class=""fas fa-times""></i>
                                </a>
                            </td>
                        </tr>
                    </tbody>
                    <tbody>
                        <tr>
                            <td>
                                <a href=""product-left-sidebar.html"">
                                    <img src=""assets/images/products/9.jpg"" class="" blur-up lazyload"" alt=""product"">
                                </a>
                            </td>
                           ");
            WriteLiteral(@" <td>
                                <a href=""product-left-sidebar.html"">Blue Jeans Color Jacket</a>
                                <div class=""mobile-cart-content row"">
                                    <div class=""col"">
                                        <div class=""qty-box"">
                                            <div class=""input-group"">
                                                <input type=""number"" name=""quantity""
                                                       class=""form-control input-number"" value=""1"" min=""1"">
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""col"">
                                        <h2>$69.00</h2>
                                    </div>
                                    <div class=""col"">
                                        <h2 class=""td-color"">
                                            <a ");
            WriteLiteral(@"href=""javascript:void(0)"">
                                                <i class=""fas fa-times""></i>
                                            </a>
                                        </h2>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <h2>$69.00</h2>
                            </td>
                            <td>
                                <div class=""qty-box"">
                                    <div class=""input-group"">
                                        <input type=""number"" name=""quantity"" class=""form-control input-number""
                                               value=""1"" min=""1"">
                                    </div>
                                </div>
                            </td>
                            <td>
                                <h2 class=""td-color"">$3219.00</h2>
                            </td");
            WriteLiteral(@">
                            <td>
                                <a href=""javascript:void(0)"">
                                    <i class=""fas fa-times""></i>
                                </a>
                            </td>
                        </tr>
                    </tbody>
                    <tbody>
                        <tr>
                            <td>
                                <a href=""product-left-sidebar.html"">
                                    <img src=""assets/images/products/8.jpg"" class=""blur-up lazyload""
                                         alt=""product"">
                                </a>
                            </td>
                            <td>
                                <a href=""product-left-sidebar.html"">Dawnbreaker Jacket</a>
                                <div class=""mobile-cart-content row"">
                                    <div class=""col"">
                                        <div class=""qty-box"">
              ");
            WriteLiteral(@"                              <div class=""input-group"">
                                                <input type=""number"" name=""quantity""
                                                       class=""form-control input-number"" value=""1"" min=""1"">
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""col"">
                                        <h2>$69.00</h2>
                                    </div>
                                    <div class=""col"">
                                        <h2 class=""td-color"">
                                            <a href=""javascript:void(0)"">
                                                <i class=""fas fa-times""></i>
                                            </a>
                                        </h2>
                                    </div>
                                </div>
                    ");
            WriteLiteral(@"        </td>
                            <td>
                                <h2>$69.00</h2>
                            </td>
                            <td>
                                <div class=""qty-box"">
                                    <div class=""input-group"">
                                        <input type=""number"" name=""quantity"" class=""form-control input-number""
                                               value=""1"" min=""1"">
                                    </div>
                                </div>
                            </td>
                            <td>
                                <h2 class=""td-color"">$4215.00</h2>
                            </td>
                            <td>
                                <a href=""javascript:void(0)"">
                                    <i class=""fas fa-times""></i>
                                </a>
                            </td>
                        </tr>
                    </tbody>
       ");
            WriteLiteral(@"         </table>
            </div>

            <div class=""col-12 mt-md-5 mt-4"">
                <div class=""row"">
                    <div class=""col-sm-7 col-5 order-1"">
                        <div class=""left-side-button text-end d-flex d-block justify-content-end"">
                            <a href=""javascript:void(0)""
                               class=""text-decoration-underline theme-color d-block text-capitalize"">
                                clear
                                all items
                            </a>
                        </div>
                    </div>
                    <div class=""col-sm-5 col-7"">
                        <div class=""left-side-button float-start"">
                            <a href=""shop.html"" class=""btn btn-solid-default btn fw-bold mb-0 ms-0"">
                                <i class=""fas fa-arrow-left""></i> Continue Shopping
                            </a>
                        </div>
                    </div>
       ");
            WriteLiteral(@"         </div>
            </div>

            <div class=""cart-checkout-section"">
                <div class=""row g-4 flex-row-reverse"">

                    <div class=""col-lg-4"">
                        <div class=""cart-box"">
                            <div class=""cart-box-details"">
                                <div class=""total-details"">
                                    <div class=""top-details"">
                                        <h3>Cart Totals</h3>
                                        <h6>Quantity of products <span>3</span></h6>
                                        <h6>Delivery <span>$0.00</span></h6>
                                        <h6><strong>Total price <span>$369.00</span></strong></h6>
                                    </div>
                                    <div class=""bottom-details"">
                                        <a href=""checkout.html"">Process Checkout</a>
                                    </div>
                                </di");
            WriteLiteral("v>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<!-- Cart Section End -->");
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
