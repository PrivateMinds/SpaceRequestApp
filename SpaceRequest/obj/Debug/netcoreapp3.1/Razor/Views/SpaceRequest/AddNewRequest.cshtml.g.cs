#pragma checksum "C:\Users\k164913\AspNetCore Trainings\SpaceRequest\Views\SpaceRequest\AddNewRequest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fbd6bae577a4fc54fd4ae438b8e4766edd44a34d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SpaceRequest_AddNewRequest), @"mvc.1.0.view", @"/Views/SpaceRequest/AddNewRequest.cshtml")]
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
#line 1 "C:\Users\k164913\AspNetCore Trainings\SpaceRequest\Views\_ViewImports.cshtml"
using SpaceRequest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\k164913\AspNetCore Trainings\SpaceRequest\Views\_ViewImports.cshtml"
using SpaceRequest.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbd6bae577a4fc54fd4ae438b8e4766edd44a34d", @"/Views/SpaceRequest/AddNewRequest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"020a48c217a9724592eba5e2e75b43d850ab5aaa", @"/Views/_ViewImports.cshtml")]
    public class Views_SpaceRequest_AddNewRequest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "EditRequest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\k164913\AspNetCore Trainings\SpaceRequest\Views\SpaceRequest\AddNewRequest.cshtml"
  
    string username = ViewBag.RequestorName;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div style=""background-color: #677083;color:white;height:100px;margin-top:.6em;"">

    <div style=""font-size:1em;font-weight: bold;margin-bottom:3px;margin-left:.9em"">KPWHRI Space Request Intake Form</div>

    <div style=""margin-left:.9em"">
        To request space for a new employee or a relocation of an existing employee, please complete the following form. For details of KPWHRI's Space Assignment Policy,
        please review the policy on KPWHRI's Intranet located here. The Space and Facilities Committee generally meets twice monthly to discuss submitted requests.
    </div>
</div>
<br />

<table style=""font-size:.9em;width:100%"">
    <tr>
        <td style=""width:15%"">
            Space RequestID
        </td>
        <td style=""width:75%"">
            ");
#nullable restore
#line 24 "C:\Users\k164913\AspNetCore Trainings\SpaceRequest\Views\SpaceRequest\AddNewRequest.cshtml"
       Write(Html.TextBoxFor(m => m.SpaceRequest.SpaceRequestID, new { id = "txtSpaceRequestID", @class = "form-control", @readonly = true, @disabled = true }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 25 "C:\Users\k164913\AspNetCore Trainings\SpaceRequest\Views\SpaceRequest\AddNewRequest.cshtml"
       Write(Html.DropDownListFor(m => m.SpaceRequest.RequestorID, new SelectList(Model.SpaceRequestList, "RequestorID", "RequestorName"), new { @id = "cboSpaceRequest", @class = "form-control standardTextBox95" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </td>\r\n    </tr>\r\n    <tr>\r\n        <td >\r\n            Requestor Name:\r\n        </td>\r\n        <td >\r\n            ");
#nullable restore
#line 34 "C:\Users\k164913\AspNetCore Trainings\SpaceRequest\Views\SpaceRequest\AddNewRequest.cshtml"
       Write(Html.TextBox("m => m.RequestorName", username, new { id = "txtRequestor", @class = "form-control", @readonly = true, @disabled = true }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </td>\r\n    </tr>\r\n    <tr><td style=\"padding-top:10px\"></td></tr>\r\n    <tr>\r\n        <td>\r\n            Requested For:\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 44 "C:\Users\k164913\AspNetCore Trainings\SpaceRequest\Views\SpaceRequest\AddNewRequest.cshtml"
       Write(Html.TextBoxFor(m => m.SpaceRequest.EmpName, new { id = "txtRequestorFor", @class = "form-control", @placeholder = "Required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

        </td>

    </tr>
    <tr>
        <td></td>
        <td>
            <div style=""margin-bottom:.5em;font-weight:bold;"">Note: Requests for space must be made by the person’s supervisor.</div>
        </td>
    </tr>
    <tr>
        <td>
            Person's FTE:
        </td>
        <td>
            ");
#nullable restore
#line 60 "C:\Users\k164913\AspNetCore Trainings\SpaceRequest\Views\SpaceRequest\AddNewRequest.cshtml"
       Write(Html.TextBoxFor(m => m.SpaceRequest.FTE, new { id = "txtFTE", @class = "form-control", @placeholder = "Required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </td>

    </tr>
    <tr>
        <td></td>
        <td>
            <div style=""margin-bottom:.5em;font-weight:bold;"">Note: FTE < 0.5 may be asked to use hoteling or share a space; FTE between 0.5 and 0.74 are only generally eligible for interior cubes.</div>
        </td>
    </tr>
    <tr>
        <td>
            Person's FTE-MPE:
        </td>
        <td>
            <div style=""margin-bottom:.6em"">
                ");
#nullable restore
#line 76 "C:\Users\k164913\AspNetCore Trainings\SpaceRequest\Views\SpaceRequest\AddNewRequest.cshtml"
           Write(Html.TextBoxFor(m => m.SpaceRequest.FTE_MPE, new { id = "txtFTEMPE", @class = "form-control", @placeholder = "Required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </td>

    </tr>
    <tr>
        <td></td>
        <td>
            <div style=""margin-bottom:.5em;font-weight:bold;"">Note: Do not include time telecommuting or working elsewhere. FTE at MPE < 0.5 may be asked to use hoteling or shared space.</div>
        </td>
    </tr>
    <tr>
        <td>
            Person's Current Space:
        </td>
        <td>
            <div style=""margin-bottom:.6em"">
                ");
#nullable restore
#line 93 "C:\Users\k164913\AspNetCore Trainings\SpaceRequest\Views\SpaceRequest\AddNewRequest.cshtml"
           Write(Html.TextBoxFor(m => m.SpaceRequest.CurrentSpace, new { id = "txtFCurrentSpace", @class = "form-control", @placeholder = "Required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </td>\r\n\r\n    </tr>\r\n    <tr>\r\n        <td>\r\n            Person\'s Job Title:\r\n        </td>\r\n        <td>\r\n            <div style=\"margin-bottom:.6em\">\r\n                ");
#nullable restore
#line 104 "C:\Users\k164913\AspNetCore Trainings\SpaceRequest\Views\SpaceRequest\AddNewRequest.cshtml"
           Write(Html.TextBoxFor(m => m.SpaceRequest.JobTitle, new { id = "txtJobTitle", @class = "form-control", @placeholder = "Required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </td>\r\n        <td>*</td>\r\n    </tr>\r\n    <tr>\r\n        <td>\r\n            Person\'s PayBand:\r\n        </td>\r\n        <td>\r\n            <div style=\"margin-bottom:.6em\">\r\n                ");
#nullable restore
#line 115 "C:\Users\k164913\AspNetCore Trainings\SpaceRequest\Views\SpaceRequest\AddNewRequest.cshtml"
           Write(Html.TextBoxFor(m => m.SpaceRequest.PayBand, new { id = "txtPayBand", @class = "form-control", @placeholder = "Required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </td>\r\n    </tr>\r\n    <tr>\r\n        <td>\r\n            Space Description:\r\n        </td>\r\n        <td>\r\n            <div style=\"margin-bottom:.9em;font-size:.3em\">\r\n                ");
#nullable restore
#line 125 "C:\Users\k164913\AspNetCore Trainings\SpaceRequest\Views\SpaceRequest\AddNewRequest.cshtml"
           Write(Html.TextAreaFor(m => m.SpaceRequest.SpaceDescription, new
                {
                    id = "txtDescription",
                    @class = "form-control",
                    rows = 5,
                    @placeholder = "Please describe your space request including preference of floor or proximity to colleagues.For new hires,please include the person’s start date.(Required)"
                }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

            </div>
        </td>

    </tr>
    <tr><td style=""padding-top:10px""></td></tr>

    <tr>
        <td></td>
        <td>
            <div style=""float:right; margin-right:24em"">
                <button id=""btnSubmitRequest"" type=""button"" class=""btn btn-info btn-lg"">SUBMIT</button>
            </div>
        </td>
    </tr>
</table>


<div id=""divSpaceRequestDetails""  style=""width:100%;visibility:hidden"">
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fbd6bae577a4fc54fd4ae438b8e4766edd44a34d11123", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 151 "C:\Users\k164913\AspNetCore Trainings\SpaceRequest\Views\SpaceRequest\AddNewRequest.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
