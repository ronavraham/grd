#pragma checksum "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c4ae926bd5768ff821f79b796f7ef6dff7a054d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Index), @"mvc.1.0.view", @"/Views/Users/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Users/Index.cshtml", typeof(AspNetCore.Views_Users_Index))]
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
#line 1 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\_ViewImports.cshtml"
using GRD;

#line default
#line hidden
#line 2 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\_ViewImports.cshtml"
using GRD.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c4ae926bd5768ff821f79b796f7ef6dff7a054d", @"/Views/Users/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"428180616247a5ccbf2b68af676c111b97b19919", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EFGetStarted.AspNetCore.NewDb.Models.User>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(63, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(106, 35, true);
            WriteLiteral("\r\n<h2>מסך משתמשים</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(141, 34, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "456db06e39674af099cc587eb6d05bf5", async() => {
                BeginContext(164, 7, true);
                WriteLiteral("צור חדש");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(175, 8, true);
            WriteLiteral("\r\n</p>\r\n");
            EndContext();
            BeginContext(183, 841, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a750976198744360852bdeb2321855af", async() => {
                BeginContext(221, 156, true);
                WriteLiteral("\r\n    <div class=\"form-actions no-color\">\r\n        <p>\r\n            חפש לפי: \r\n            <select name=\"FilterType\" style=\"height:27px;\">\r\n                ");
                EndContext();
                BeginContext(377, 84, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1df91b54fcbb4801ab430b753b948840", async() => {
                    BeginContext(444, 8, true);
                    WriteLiteral("שם משתמש");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "selected", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 17 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
AddHtmlAttributeValue("", 395, (string)ViewData["filterType"] == "שם משתמש", 395, 47, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(461, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(479, 78, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2274ad46ae3a4f31b2ba4a836f8d84c6", async() => {
                    BeginContext(543, 5, true);
                    WriteLiteral("סיסמא");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "selected", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 18 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
AddHtmlAttributeValue("", 497, (string)ViewData["filterType"] == "סיסמא", 497, 44, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(557, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(575, 78, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12b051dc192844d68ef03dd2a5346fda", async() => {
                    BeginContext(639, 5, true);
                    WriteLiteral("כתובת");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "selected", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 19 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
AddHtmlAttributeValue("", 593, (string)ViewData["filterType"] == "כתובת", 593, 44, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(653, 75, true);
                WriteLiteral("\r\n            </select>\r\n            <input type=\"text\" name=\"SearchString\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 728, "\"", 762, 1);
#line 21 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
WriteAttributeValue("", 736, ViewData["currentFilter"], 736, 26, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(763, 183, true);
                WriteLiteral(" />\r\n            <input placeholder=\"ערך חיפוש\" type=\"submit\" value=\"חפש\" class=\"btn btn-default\" style=\"height: 27px;padding: 0 0 0 0;width: 70px;margin-top: -2px;\"/> |\r\n            ");
                EndContext();
                BeginContext(946, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "16c234f4a888486f800eacb8d8ac0aef", async() => {
                    BeginContext(968, 17, true);
                    WriteLiteral("בחזרה לרשימה מלאה");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(989, 28, true);
                WriteLiteral("\r\n        </p>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1024, 111, true);
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th style=\"text-align:right\">\r\n                ");
            EndContext();
            BeginContext(1136, 44, false);
#line 31 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Username));

#line default
#line hidden
            EndContext();
            BeginContext(1180, 80, true);
            WriteLiteral("\r\n            </th>\r\n            <th style=\"text-align:right\">\r\n                ");
            EndContext();
            BeginContext(1261, 44, false);
#line 34 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Password));

#line default
#line hidden
            EndContext();
            BeginContext(1305, 80, true);
            WriteLiteral("\r\n            </th>\r\n            <th style=\"text-align:right\">\r\n                ");
            EndContext();
            BeginContext(1386, 43, false);
#line 37 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(1429, 80, true);
            WriteLiteral("\r\n            </th>\r\n            <th style=\"text-align:right\">\r\n                ");
            EndContext();
            BeginContext(1510, 42, false);
#line 40 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
            EndContext();
            BeginContext(1552, 80, true);
            WriteLiteral("\r\n            </th>\r\n            <th style=\"text-align:right\">\r\n                ");
            EndContext();
            BeginContext(1633, 43, false);
#line 43 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IsAdmin));

#line default
#line hidden
            EndContext();
            BeginContext(1676, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 49 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1811, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1872, 43, false);
#line 53 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Username));

#line default
#line hidden
            EndContext();
            BeginContext(1915, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1983, 43, false);
#line 56 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Password));

#line default
#line hidden
            EndContext();
            BeginContext(2026, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2094, 42, false);
#line 59 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
            EndContext();
            BeginContext(2136, 47, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
            EndContext();
#line 62 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
                      
                        if (item.Gender == false)
                        { 

#line default
#line hidden
            BeginContext(2290, 3, true);
            WriteLiteral("זכר");
            EndContext();
#line 64 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
                                           }
                    else
                    { 

#line default
#line hidden
            BeginContext(2358, 4, true);
            WriteLiteral("נקבה");
            EndContext();
#line 66 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
                                        }
                    

#line default
#line hidden
            BeginContext(2396, 45, true);
            WriteLiteral("                </td>\r\n                <td>\r\n");
            EndContext();
#line 70 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
                      
                        if (item.IsAdmin == false)
                        { 

#line default
#line hidden
            BeginContext(2549, 2, true);
            WriteLiteral("לא");
            EndContext();
#line 72 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
                                          }
                    else
                    { 

#line default
#line hidden
            BeginContext(2616, 2, true);
            WriteLiteral("כן");
            EndContext();
#line 74 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
                                      }
                    

#line default
#line hidden
            BeginContext(2652, 65, true);
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2717, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7454414601864c0bac08f3976f7aea3e", async() => {
                BeginContext(2762, 4, true);
                WriteLiteral("ערוך");
                EndContext();
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
#line 78 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
                                           WriteLiteral(item.Id);

#line default
#line hidden
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
            EndContext();
            BeginContext(2770, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(2794, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2e96942561064a9e91591e8dabd3694d", async() => {
                BeginContext(2842, 7, true);
                WriteLiteral("ראה עוד");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 79 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
                                              WriteLiteral(item.Id);

#line default
#line hidden
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
            EndContext();
            BeginContext(2853, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(2877, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66189d3c12a644e082a2181d0b2deb44", async() => {
                BeginContext(2924, 3, true);
                WriteLiteral("מחק");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 80 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
                                             WriteLiteral(item.Id);

#line default
#line hidden
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
            EndContext();
            BeginContext(2931, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 83 "C:\Users\רון אברהם\Source\Repos\grd\GRD\GRD\Views\Users\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2986, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EFGetStarted.AspNetCore.NewDb.Models.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
