#pragma checksum "C:\Users\Yasemin BADILLI\Source\repos\Staj Takip\staj-takip-1\StajyerTakip\Views\Stajyer\Ekle.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1cea92b8f72747d36d0ea297ee4d0a704104a84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Stajyer_Ekle), @"mvc.1.0.view", @"/Views/Stajyer/Ekle.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Stajyer/Ekle.cshtml", typeof(AspNetCore.Views_Stajyer_Ekle))]
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
#line 1 "C:\Users\Yasemin BADILLI\Source\repos\Staj Takip\staj-takip-1\StajyerTakip\Views\_ViewImports.cshtml"
using StajyerTakip;

#line default
#line hidden
#line 2 "C:\Users\Yasemin BADILLI\Source\repos\Staj Takip\staj-takip-1\StajyerTakip\Views\_ViewImports.cshtml"
using StajyerTakip.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1cea92b8f72747d36d0ea297ee4d0a704104a84", @"/Views/Stajyer/Ekle.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36bb4488a1d3f22c397e329b2db506fdf7d0f226", @"/Views/_ViewImports.cshtml")]
    public class Views_Stajyer_Ekle : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("forms-sample"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Yasemin BADILLI\Source\repos\Staj Takip\staj-takip-1\StajyerTakip\Views\Stajyer\Ekle.cshtml"
  
    ViewData["Title"] = "Ekle";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(89, 205, true);
            WriteLiteral("\r\n    <div class=\"col-md-6 grid-margin stretch-card\">\r\n        <div class=\"card\">\r\n            <div class=\"card-body\">\r\n                <h4 class=\"card-title\">Öğrenci Bilgileri</h4>\r\n\r\n\r\n\r\n                ");
            EndContext();
            BeginContext(294, 4096, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "de8c924f251042f8ba7edc2336621969", async() => {
                BeginContext(335, 4048, true);
                WriteLiteral(@"
                    <div class=""form-group"">
                        <label for=""ad"">Ad</label>
                        <input type=""text"" class=""form-control"" id=""ad"" name=""Profil.Ad"" placeholder=""Ad"">
                    </div>
                    <div class=""form-group"">
                        <label for=""soyad"">Soyad</label>
                        <input type=""text"" class=""form-control"" id=""soyad"" name=""Profil.Soyad"" placeholder=""Soyad"">
                    </div>
                    <div class=""form-group"">
                        <label for=""kullaniciadi"">Kullanıcı Adı</label>
                        <input type=""text"" class=""form-control"" id=""kullaniciadi"" name=""Profil.KullaniciAdi ""placeholder=""Kullancı Adı"">
                    </div>

                    <div class=""form-group"">
                        <label for=""email"">Email Adres</label>
                        <input type=""email"" class=""form-control"" id=""email"" name=""Profil.Email"" placeholder=""Email"">
                    </di");
                WriteLiteral(@"v>
                    <div class=""form-group"">
                        <label for=""sifre"">Şifre</label>
                        <input type=""password"" class=""form-control"" id=""sifre"" name=""Profil.Sifre""placeholder=""Şifre"">
                    </div>
                    <div class=""form-group"">
                        <label for=""telefonnumarasi"">Telefon Numarası:</label>
                        <input type=""text"" class=""form-control bfh-phone"" data-format=""+1 (ddd) ddd-dddd"" name=""Profil.Telefon"" placeholder=""Telefon Numarası"">
                    </div>
                    <div class=""form-group"">
                        <label for=""okul"">Okulu:</label>
                        <input type=""text"" class=""form-control"" id=""okul"" name=""Okul"" placeholder=""Okul"">
                    </div>

                    <div class=""form-group"">
                        <label for=""bolum"">Bölümü:</label>
                        <input type=""text"" class=""form-control"" id=""bolum"" name=""Bolum"" placeholder=""Bölüm");
                WriteLiteral(@""">
                    </div>

                    <div class=""form-group"">
                        <label for=""adres"">Adres</label>
                        <input type=""text"" class=""form-control"" id=""adres"" name=""Profil.Adres"" placeholder=""Adres"">
                    </div>

                    <div class=""form-row"">
                        <div class=""form-group col-sm-4"">
                            <label for=""il"">İl</label>
                            <input type=""text"" class=""form-control"" id=""il"" name=""Profil.Il"" placeholder=""İl"">
                        </div>

                        <div class=""form-group col-sm-4"">
                            <label for=""ilce"">İlçe</label>
                            <input type=""text"" class=""form-control"" id=""ilce"" name=""Profil.Ilce"" placeholder=""İlçe"">
                        </div>

                        <div class=""form-group col-sm-4"">
                            <label for=""sokak"">Sokak</label>
                            <input type=""t");
                WriteLiteral(@"ext"" class=""form-control"" id=""sokak"" name=""Profil.Sokak"" placeholder=""Sokak"">
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label>Fotoğraf</label>
                        <input type=""file"" name=""img[]"" class=""file-upload-default"">
                        <div class=""input-group col-xs-12"">
                            <input type=""text"" class=""form-control file-upload-info"" name=""Profil.Fotograf"" disabled placeholder=""Fotoğraf Yükle"">
                            <span class=""input-group-append"">
                                <button class=""file-upload-browse btn btn-success"" type=""button"">Yükle</button>
                            </span>
                        </div>
                    </div>
                    <button type=""submit"" class=""btn btn-success mr-2"">Kaydet</button>
                    <button class=""btn btn-primary"">İptal</button>

                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4390, 50, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
