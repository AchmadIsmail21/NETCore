#pragma checksum "C:\Users\achma\source\repos\NETCore\ImplementCors\Views\ClientAPI\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0bb11812f27808cb6ff1455929d627fb2dbbe37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ClientAPI_Index), @"mvc.1.0.view", @"/Views/ClientAPI/Index.cshtml")]
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
#line 1 "C:\Users\achma\source\repos\NETCore\ImplementCors\Views\_ViewImports.cshtml"
using ImplementCors;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\achma\source\repos\NETCore\ImplementCors\Views\_ViewImports.cshtml"
using ImplementCors.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0bb11812f27808cb6ff1455929d627fb2dbbe37", @"/Views/ClientAPI/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f43793de8ec3e89ecacd12908e57073eb5edd501", @"/Views/_ViewImports.cshtml")]
    public class Views_ClientAPI_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formRegister"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/client.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\achma\source\repos\NETCore\ImplementCors\Views\ClientAPI\Index.cshtml"
   Layout = "~/Views/Shared/AdminLTE/_Layout.cshtml"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container mt-4"">
    <div class=""card"">
        <div class=""card-header"">
            <div class=""row"">
                <p class=""h1 col-8"">Data Person</p>
                <div class=""col-4"">
                    <button data-toggle=""modal""
                            data-target=""#registerModal""
                            class=""btn btn-primary float-right"">
                        Register
                    </button>
                </div>
                
            </div>
        </div>
        <div class=""card-body"">
            <table id=""tableClient"" class=""table table-hover table-bordered"">
                <thead>
                    <tr>
                        <th>No</th>
                        <th>NIK</th>
                        <th>Name</th>
                        <th>Email</th>
                        <th>Phone</th>
                        <th>Action</th>
                        <th>Action</th>
                    </tr>
                </thead>
      ");
            WriteLiteral("          <tbody id=\"bodyClient\">\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            WriteLiteral(@"<div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Client Detail</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"" id=""bodyModal"">

            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <button type=""button"" class=""btn btn-primary"">Save changes</button>
            </div>
        </div>
    </div>
</div>

");
            WriteLiteral(@"<div class=""modal fade"" id=""registerModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""registerModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""registerModalLabel"">Register</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"" id=""bodyRegisterModal"">

                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0bb11812f27808cb6ff1455929d627fb2dbbe378265", async() => {
                WriteLiteral(@"
                    <div class=""form-row"">
                        <div class=""col-8"">
                            <label for=""inputNIK"">NIK</label>
                            <input type=""text"" class=""form-control"" id=""inputNIK"" placeholder=""NIK"" required>
                            <div class=""valid-feedback"">NIK valid</div>
                            <div class=""invalid-feedback"">
                                <span id=""msgNIK""></span>
                            </div>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""col-md-4 mb-3"">
                            <label for=""inputFirstName"">First name</label>
                            <input type=""text"" class=""form-control"" id=""inputFirstName"" placeholder=""First name"" required>
                            <div class=""valid-feedback"">First Name valid</div>
                            <div class=""invalid-feedback"">
                                <s");
                WriteLiteral(@"pan id=""msgFirstName""></span>
                            </div>
                        </div>

                        <div class=""col-md-4 mb-3"">
                            <label for=""inputLastName"">Last name</label>
                            <input type=""text"" class=""form-control"" id=""inputLastName"" placeholder=""Last name"" required>
                            <div class=""valid-feedback"">Last Name valid</div>
                            <div class=""invalid-feedback"">
                                <span id=""msgLastName""></span>
                            </div>
                        </div>

                    </div>

                    <div class=""form-row"">
                        <div class=""col-8"">
                            <label for=""inputPhone"">Phone</label>
                            <input type=""text"" class=""form-control"" id=""inputPhone"" placeholder=""Phone"" required>
                            <div class=""valid-feedback"">Phone Number valid</div>
                  ");
                WriteLiteral(@"          <div class=""invalid-feedback"">
                                <span id=""msgPhone""></span>
                            </div>
                        </div>
                    </div>

                    <div class=""form-row"">
                        <div class=""col-8"">
                            <label for=""inputBirthDate"">Birth Date</label>
                            <input type=""datetime"" class=""form-control"" id=""inputBirthDate"" placeholder=""Birth Date"" value=""1997-07-20"" required>
                            <div class=""valid-feedback"">Birth Date valid</div>
                            <div class=""invalid-feedback"">
                                <span id=""msgBirthDate""></span>
                            </div>
                        </div>
                    </div>

                    <div class=""form-group"">
                        <div class=""col-8"">
                            <label for=""inputGender"">Choose your Gender:</label>
                            <select");
                WriteLiteral(" id=\"inputGender\" name=\"inputGenderName\" class=\"form-control\" required>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0bb11812f27808cb6ff1455929d627fb2dbbe3711918", async() => {
                    WriteLiteral("Male");
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
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0bb11812f27808cb6ff1455929d627fb2dbbe3713172", async() => {
                    WriteLiteral("Female");
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
                WriteLiteral(@"

                            </select>
                            <div class=""valid-feedback"">Gender valid</div>
                            <div class=""invalid-feedback"">
                                <span id=""msgGender""></span>
                            </div>
                        </div>
                    </div>

                    <div class=""form-row"">
                        <div class=""col-8"">
                            <label for=""inputSalary"">Salary</label>
                            <input type=""number"" class=""form-control"" id=""inputSalary"" placeholder=""Salary"" required>
                            <div class=""valid-feedback"">Salary valid</div>
                            <div class=""invalid-feedback"">
                                <span id=""msgSalary""></span>
                            </div>
                        </div>
                    </div>

                    <div class=""form-row"">
                        <div class=""col-8"">
                       ");
                WriteLiteral(@"     <label for=""inputEmail"">Email</label>
                            <input type=""text"" class=""form-control"" id=""inputEmail"" placeholder=""Email"" required>
                            <div class=""valid-feedback"">Email valid</div>
                            <div class=""invalid-feedback"">
                                <span id=""msgEmail""></span>
                            </div>
                        </div>
                    </div>

                    <div class=""form-row"">
                        <div class=""col-8"">
                            <label for=""inputPassword"">Password</label>
                            <input type=""text"" class=""form-control"" id=""inputPassword"" placeholder=""Password"" required>
                            <div class=""valid-feedback"">Password valid</div>
                            <div class=""invalid-feedback"">
                                <span id=""msgPassword""></span>
                            </div>
                        </div>
                  ");
                WriteLiteral(@"  </div>

                    <div class=""form-row"">
                        <div class=""col-4"">
                            <label for=""inputDegree"">Degree</label>
                            <input type=""text"" class=""form-control"" id=""inputDegree"" placeholder=""Degree"" required>
                            <div class=""valid-feedback"">Degree valid</div>
                            <div class=""invalid-feedback"">
                                <span id=""msgDegree""></span>
                            </div>
                        </div>

                        <div class=""col-4"">
                            <label for=""inputGPA"">Gpa</label>
                            <input type=""text"" class=""form-control"" id=""inputGPA"" placeholder=""Gpa"" required>
                            <div class=""valid-feedback"">GPA valid</div>
                            <div class=""invalid-feedback"">
                                <span id=""msgGPA""></span>
                            </div>
                      ");
                WriteLiteral(@"  </div>
                    </div>

                    <div class=""form-row"">
                        <div class=""col-8"">
                            <label for=""inputUniversity"">Universities</label>
                            <select id=""inputUniversity"" name=""inputUniversityName"" class=""form-control"" required>
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0bb11812f27808cb6ff1455929d627fb2dbbe3718045", async() => {
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
                            <div class=""valid-feedback"">University valid</div>
                            <div class=""invalid-feedback"">
                                <span id=""msgUniversity""></span>
                            </div>
                        </div>

                    </div>


");
                WriteLiteral("\r\n");
                WriteLiteral("                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <button id=""registerBtn"" type=""button"" class=""btn btn-primary"">Register</button>
            </div>
        </div>                                                                                                               
    </div>
</div>
");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0bb11812f27808cb6ff1455929d627fb2dbbe3721261", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 257 "C:\Users\achma\source\repos\NETCore\ImplementCors\Views\ClientAPI\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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
