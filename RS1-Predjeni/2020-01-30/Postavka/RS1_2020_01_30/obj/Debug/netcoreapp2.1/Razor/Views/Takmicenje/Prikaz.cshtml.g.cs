#pragma checksum "C:\Users\PC\Desktop\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Prikaz.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52b363c663b07bdc86427d322a80f546feda3540"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Takmicenje_Prikaz), @"mvc.1.0.view", @"/Views/Takmicenje/Prikaz.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Takmicenje/Prikaz.cshtml", typeof(AspNetCore.Views_Takmicenje_Prikaz))]
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
#line 1 "C:\Users\PC\Desktop\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Prikaz.cshtml"
using RS1_2020_01_30.VM;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52b363c663b07bdc86427d322a80f546feda3540", @"/Views/Takmicenje/Prikaz.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0909514ccbe15c9b46987fb6fc827edf50cf04a", @"/Views/_ViewImports.cshtml")]
    public class Views_Takmicenje_Prikaz : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TakmicenjePrikazVM>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(27, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(56, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(60, 1392, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a186ebdf53314c82897b948085db9fd4", async() => {
                BeginContext(66, 86, true);
                WriteLiteral("\r\n    <div class=\"container\">\r\n        <br /><br /><br />\r\n        <h3>Škola domaćin: ");
                EndContext();
                BeginContext(153, 19, false);
#line 9 "C:\Users\PC\Desktop\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Prikaz.cshtml"
                      Write(Model.OdabranaSkola);

#line default
#line hidden
                EndContext();
                BeginContext(172, 27, true);
                WriteLiteral("</h3>\r\n        <h3>Razred: ");
                EndContext();
                BeginContext(200, 20, false);
#line 10 "C:\Users\PC\Desktop\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Prikaz.cshtml"
               Write(Model.OdabraniRazred);

#line default
#line hidden
                EndContext();
                BeginContext(220, 502, true);
                WriteLiteral(@"</h3>
        <table class=""table table-bordered"">
            <thead>
                <tr>
                    <td>Takmicenje ID</td>
                    <td>Predmet</td>
                    <td>Razred</td>
                    <td>Datum</td>
                    <td>Broj učesnika koji nisu pristupili</td>
                    <td>Najbolji učesnik(Škola | Odjeljenje | Ime i prezime)</td>
                    <td>Akcija</td>
                </tr>
            </thead>
            <tbody>
");
                EndContext();
#line 24 "C:\Users\PC\Desktop\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Prikaz.cshtml"
                 foreach (TakmicenjePrikazVM.Row x in Model.ListaTaknmicenja)
                {

#line default
#line hidden
                BeginContext(820, 54, true);
                WriteLiteral("                    <tr>\r\n                        <td>");
                EndContext();
                BeginContext(875, 14, false);
#line 27 "C:\Users\PC\Desktop\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Prikaz.cshtml"
                       Write(x.TakmicenjeID);

#line default
#line hidden
                EndContext();
                BeginContext(889, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(925, 9, false);
#line 28 "C:\Users\PC\Desktop\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Prikaz.cshtml"
                       Write(x.Predmet);

#line default
#line hidden
                EndContext();
                BeginContext(934, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(970, 8, false);
#line 29 "C:\Users\PC\Desktop\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Prikaz.cshtml"
                       Write(x.Razred);

#line default
#line hidden
                EndContext();
                BeginContext(978, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(1014, 7, false);
#line 30 "C:\Users\PC\Desktop\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Prikaz.cshtml"
                       Write(x.Datum);

#line default
#line hidden
                EndContext();
                BeginContext(1021, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(1057, 28, false);
#line 31 "C:\Users\PC\Desktop\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Prikaz.cshtml"
                       Write(x.BrojUcesnik_NisuPristupili);

#line default
#line hidden
                EndContext();
                BeginContext(1085, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(1121, 17, false);
#line 32 "C:\Users\PC\Desktop\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Prikaz.cshtml"
                       Write(x.NajboljiUcesnik);

#line default
#line hidden
                EndContext();
                BeginContext(1138, 37, true);
                WriteLiteral("</td>\r\n                        <td><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1175, "\"", 1226, 2);
                WriteAttributeValue("", 1182, "/Takmicenje/Rezultati?idtakm=", 1182, 29, true);
#line 33 "C:\Users\PC\Desktop\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Prikaz.cshtml"
WriteAttributeValue("", 1211, x.TakmicenjeID, 1211, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1227, 48, true);
                WriteLiteral(">Rezultati</a></td>\r\n                    </tr>\r\n");
                EndContext();
#line 35 "C:\Users\PC\Desktop\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Prikaz.cshtml"
                }

#line default
#line hidden
                BeginContext(1294, 82, true);
                WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    <a class=\"btn btn-primary\"");
                EndContext();
                BeginWriteAttribute("href", "href=\"", 1376, "\"", 1430, 2);
                WriteAttributeValue("", 1382, "/Takmicenje/Dodaj?idSkola=", 1382, 26, true);
#line 39 "C:\Users\PC\Desktop\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Prikaz.cshtml"
WriteAttributeValue("", 1408, Model.OdabranaSkolaID, 1408, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1431, 14, true);
                WriteLiteral(">Dodaj</a>\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TakmicenjePrikazVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
