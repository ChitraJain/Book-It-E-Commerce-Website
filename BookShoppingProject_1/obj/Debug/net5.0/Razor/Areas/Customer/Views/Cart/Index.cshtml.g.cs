#pragma checksum "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "893b2467f94bcef9e2100080ad999feaa21eaa49"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Cart_Index), @"mvc.1.0.view", @"/Areas/Customer/Views/Cart/Index.cshtml")]
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
#line 1 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\_ViewImports.cshtml"
using BookShoppingProject_1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\_ViewImports.cshtml"
using BookShoppingProject_1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"893b2467f94bcef9e2100080ad999feaa21eaa49", @"/Areas/Customer/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77ef69e5bba2074a6518686a89435d756554348f", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BookShoppingProject_1.Models.ViewModels.ShoppingCartVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-info btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "plus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "minus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Summary", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "893b2467f94bcef9e2100080ad999feaa21eaa497945", async() => {
                WriteLiteral("\n    <br />\n");
#nullable restore
#line 4 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
     if (Model.listCart.Count() > 0)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"<div class=""backgroundWhiteBorder"">
    <div class=""container"">
        <div class=""card"">
            <div class=""card-header bg-dark text-light ml-0 row container"">
                <div class=""col-6"">
                    <i class=""fa fa-shopping-cart""></i> &nbsp;
                    Shopping Cart
                </div>
                <div class=""col-6 text-right"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "893b2467f94bcef9e2100080ad999feaa21eaa498847", async() => {
                    WriteLiteral("Continue Shopping");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
                WriteLiteral("\n                </div>\n            </div>\n            <div class=\"card-body\">\n");
#nullable restore
#line 19 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
                 foreach (var item in Model.listCart)
                {
                    var amount = item.Count * item.Price;

#line default
#line hidden
#nullable disable
                WriteLiteral("<div class=\"row\">\n    <div class=\"d-none d-lg-block col-lg-1 text-center py-2\">\n        <img");
                BeginWriteAttribute("src", " src=\"", 929, "\"", 957, 1);
#nullable restore
#line 24 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
WriteAttributeValue("", 935, item.Product.imageUrl, 935, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"rounded\" style=\"width:100px; height:100px\" />\n    </div>\n    <div class=\"col-12 text-sm-center col-lg-6 text-lg-left\">\n        <h5><strong>");
#nullable restore
#line 27 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
               Write(item.Product.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong></h5>\n        <h6><small>");
#nullable restore
#line 28 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
              Write(Html.Raw(item.Product.Description));

#line default
#line hidden
#nullable disable
                WriteLiteral("</small></h6> \n    </div>\n    <div class=\"col-12 text-sm-center col-lg-5 text-lg-right row\">\n        <div class=\"col-4 text-md-right\" style=\"padding-top:5px;\">\n            <h6><strong>");
#nullable restore
#line 32 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
                   Write(item.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("<span class=\"text-muted\">x</span> ");
#nullable restore
#line 32 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
                                                                Write(item.Count);

#line default
#line hidden
#nullable disable
                WriteLiteral(" = $");
#nullable restore
#line 32 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
                                                                               Write(amount);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </strong></h6>\n        </div>\n        <div class=\"col-6 col-sm-4 col-lg-6\">\n            <div class=\"float-right mx-1\">\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "893b2467f94bcef9e2100080ad999feaa21eaa4913067", async() => {
                    WriteLiteral("\n                    <i class=\"fas fa-plus\"></i>\n                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-cartId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
                                           WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["cartId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-cartId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["cartId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n            </div>\n            <div class=\"float-right mx-1\">\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "893b2467f94bcef9e2100080ad999feaa21eaa4915554", async() => {
                    WriteLiteral("\n                    <i class=\"fas fa-minus\"></i>\n                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-cartId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
                                            WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["cartId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-cartId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["cartId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n            </div>\n        </div>\n        <div class=\"col-2 col-sm-4 col-lg-2 text-right\">\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "893b2467f94bcef9e2100080ad999feaa21eaa4918069", async() => {
                    WriteLiteral("\n                <i class=\"fas fa-trash\"></i>\n            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-cartId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
                                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["cartId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-cartId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["cartId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n        </div>\n    </div>\n\n</div>          ");
#nullable restore
#line 53 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                <hr />

                <div class=""row"">
                    <div class=""col-12 col-md-6 offset-md-6 col-lg-4 offset-lg-8 pr-4"">
                        <ul class=""list-group"">
                            <li class=""list-group-item d-flex justify-content-between bg-light"">
                                <span class=""text-info""> Total (USD)</span>
                                <strong class=""text-info"">$ <span id=""txtOrderTotal"">");
#nullable restore
#line 61 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
                                                                                Write(Model.OrderHeader.OrderTotal);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></strong>\n                            </li>\n                        </ul>\n                    </div>\n                </div>\n            </div>\n            <div class=\"card-footer\">\n                <div class=\"card-footer row\">\n");
#nullable restore
#line 69 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
                     if(!Model.OrderHeader.ApplicationUser.EmailConfirmed)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div");
                BeginWriteAttribute("class", " class=\"", 3054, "\"", 3085, 2);
                WriteAttributeValue("", 3062, "col-8", 3062, 5, true);
#nullable restore
#line 71 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
WriteAttributeValue(" ", 3067, ViewBag.EmailCSS, 3068, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n                ");
#nullable restore
#line 72 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
           Write(ViewBag.EmailMessage);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n            </div>\n            <div class=\"col-4\">\n                <button type=\"submit\" class=\"btn btn-outline-warning\">Click here to resend Confirmation Email!!</button>\n            </div>\n");
#nullable restore
#line 77 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"col-sm-12 col-lg-4 col-md-6 offset-lg-8 offset-md-6 \">\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "893b2467f94bcef9e2100080ad999feaa21eaa4923236", async() => {
                    WriteLiteral("Summary");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_10.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_11.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n            </div>\n");
#nullable restore
#line 83 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </div>\n            </div>\n        </div>\n    </div>\n</div>\n");
#nullable restore
#line 92 "E:\Devesh\BookShoppingProject_1\Areas\Customer\Views\Cart\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_13.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_13);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BookShoppingProject_1.Models.ViewModels.ShoppingCartVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
