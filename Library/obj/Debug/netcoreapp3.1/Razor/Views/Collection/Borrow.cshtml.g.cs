#pragma checksum "C:\Users\Madalina\source\repos\Library\Library\Views\Collection\Borrow.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a455bdf0da885d378aee6a3a5ae460c6bf679daf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Collection_Borrow), @"mvc.1.0.view", @"/Views/Collection/Borrow.cshtml")]
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
#line 1 "C:\Users\Madalina\source\repos\Library\Library\Views\_ViewImports.cshtml"
using Library.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Madalina\source\repos\Library\Library\Views\_ViewImports.cshtml"
using Library.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a455bdf0da885d378aee6a3a5ae460c6bf679daf", @"/Views/Collection/Borrow.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a56047992f69f9b3fff13148d7dcc5f0c434115", @"/Views/_ViewImports.cshtml")]
    public class Views_Collection_Borrow : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Library.Web.Models.BorrowModel.BorrowModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<style>

    .button {
        background-color: #900C3F;
        border: none;
        color: white;
        padding: 16px 32px;
        text-align: center;
        font-size: 16px;
        margin: 4px 2px;
        opacity: 0.6;
        transition: 0.3s;
        display: inline-block;
        text-decoration: none;
        cursor: pointer;
        border-radius: 12px;
    }

        .button:hover {
            opacity: 1
        }
    p.ex1 {
        font-size: 40px;
    }
</style>

<div class=""container"">
    <div class=""card-header clearfix detailHeading"" style=""background-color:#e6b3b3"">
        <h2>Borrow an Item</h2>

    </div>
</div>

<div class=""jumbotron"" style=""background-color:#f6eeee"">
    <div class=""row"">
        <div class=""col-md-3"">
            <div>
                <p class=""ex1"" id=""itemTitle"" style=""color:#7d0f42;""><span style=""font-weight:bold"">");
#nullable restore
#line 39 "C:\Users\Madalina\source\repos\Library\Library\Views\Collection\Borrow.cshtml"
                                                                                               Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></p>\r\n                <img class=\"detailImage\"");
            BeginWriteAttribute("src", " src=\"", 1032, "\"", 1053, 1);
#nullable restore
#line 40 "C:\Users\Madalina\source\repos\Library\Library\Views\Collection\Borrow.cshtml"
WriteAttributeValue("", 1038, Model.ImageUrl, 1038, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"250\" height=\"350\" />\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-9\">\r\n");
#nullable restore
#line 44 "C:\Users\Madalina\source\repos\Library\Library\Views\Collection\Borrow.cshtml"
             using (Html.BeginForm("PlaceBorrow", "Collection", FormMethod.Post))
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\Madalina\source\repos\Library\Library\Views\Collection\Borrow.cshtml"
           Write(Html.HiddenFor(i => i.ItemId));

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div>\r\n                    <span style=\"font-style:italic\">\r\n                        Please insert a Library Subscription ID</span>\r\n                        ");
#nullable restore
#line 50 "C:\Users\Madalina\source\repos\Library\Library\Views\Collection\Borrow.cshtml"
                   Write(Html.TextBoxFor(i => i.LibrarySubscriptionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n                <div>\r\n                    <button type=\"submit\" class=\"mdl-button mdl-button--colored button\">Borrow</button>\r\n                </div>\r\n");
#nullable restore
#line 55 "C:\Users\Madalina\source\repos\Library\Library\Views\Collection\Borrow.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Library.Web.Models.BorrowModel.BorrowModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
