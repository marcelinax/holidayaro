#pragma checksum "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c0f916d9627adac8cc86f2c640a0cc6d2219178f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PaymentsAdmin_Index), @"mvc.1.0.view", @"/Views/PaymentsAdmin/Index.cshtml")]
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
#line 1 "D:\Studia\Semestr 5\Holidayaro\Views\_ViewImports.cshtml"
using Holidayaro;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Studia\Semestr 5\Holidayaro\Views\_ViewImports.cshtml"
using Holidayaro.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0f916d9627adac8cc86f2c640a0cc6d2219178f", @"/Views/PaymentsAdmin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"658d522166f28506f689c78ba963dd4914d62e45", @"/Views/_ViewImports.cshtml")]
    public class Views_PaymentsAdmin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "10", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "15", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "20", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 4 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
  
    ViewData["Title"] = "Payments";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script>\r\n    var totalItems = ");
#nullable restore
#line 10 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
                Write(ViewBag.Results.amount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
</script>

<h5>Payments</h5>


<div class=""table-box d-flex flex-column"">
    <div class=""table-box-top d-flex justify-content-end align-items-center"">
        <div class=""table-box-top-options d-flex align-items-end"">
            <div class=""row mr-5 align-items-end"">
                <label class=""mb-0 mr-2"">Show items</label>
                <select id=""show-items-select"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0f916d9627adac8cc86f2c640a0cc6d2219178f5308", async() => {
                WriteLiteral("All");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
                       WriteLiteral(ViewBag.Results.amount);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0f916d9627adac8cc86f2c640a0cc6d2219178f6932", async() => {
                WriteLiteral("10");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0f916d9627adac8cc86f2c640a0cc6d2219178f8107", async() => {
                WriteLiteral("15");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0f916d9627adac8cc86f2c640a0cc6d2219178f9282", async() => {
                WriteLiteral("20");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </select>
            </div>
            <div class=""row align-items-end"">
                <label class=""mb-0""  id=""items-amount-heading""></label>
                <div class=""btns-box d-flex ml-3"">
                    <button class=""btn"" id=""previous-page-btn""><i class='bx bx-chevron-left'></i></button>
                    <button class=""btn"" id=""next-page-btn""><i class='bx bx-chevron-right'></i></button>
                </div>
            </div>
        </div>
    </div>
    <table class=""table"">
        <thead>
            <tr>
                <th>
                    PaymentId
                </th>
                <th>
                    ReservationId
                </th>

                <th>
                    Name & Surname
                </th>
                <th>
                   HotelId
                </th>
                <th>
                    Credit Card Number
                </th>
                <th>
                    Credit Card Holde");
            WriteLiteral(@"r Name
                </th>
                <th>
                    Credit Card Expiration
                </th>
                <th>
                    Credit Card Cvv
                </th>
                <th>
                    Paypal Email
                </th>
                <th>
                    Payment Amount
                </th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 75 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
             foreach (var item in ViewBag.Results.results)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    <div> ");
#nullable restore
#line 79 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
                     Write(item.PaymentId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </td>\r\n                <td>\r\n                    <div> ");
#nullable restore
#line 82 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
                     Write(item.ReservationId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </td>\r\n                <td>\r\n                    <div>  ");
#nullable restore
#line 85 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
                      Write(item.Reservation.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 85 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
                                              Write(item.Reservation.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </td>\r\n                <td>\r\n                    <div> ");
#nullable restore
#line 88 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
                     Write(item.Reservation.HotelId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </td>\r\n                <td>\r\n                    <div> ");
#nullable restore
#line 91 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
                     Write(item.CreditCardNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </td>\r\n\r\n                <td>\r\n                    <div> ");
#nullable restore
#line 95 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
                     Write(item.CreditCardHolderName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </td>\r\n                <td>\r\n                    <div>");
#nullable restore
#line 98 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
                    Write(item.CreditCardExpirationMonth);

#line default
#line hidden
#nullable disable
            WriteLiteral(".");
#nullable restore
#line 98 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
                                                    Write(item.CreditCardExpirationYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </td>\r\n                <td>\r\n                    <div>");
#nullable restore
#line 101 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
                    Write(item.CreditCardCvv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </td>\r\n                <td>\r\n                    <div>");
#nullable restore
#line 104 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
                    Write(item.PaypalEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </td>\r\n                <td>\r\n                    <div>");
#nullable restore
#line 107 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
                    Write(item.PaymentAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </td>\r\n\r\n\r\n\r\n\r\n                <td>\r\n                    <div>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0f916d9627adac8cc86f2c640a0cc6d2219178f15967", async() => {
                WriteLiteral("\r\n                            <i class=\'bx bx-trash-alt\'></i>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 115 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
                                                 WriteLiteral(item.PaymentId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 122 "D:\Studia\Semestr 5\Holidayaro\Views\PaymentsAdmin\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
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
