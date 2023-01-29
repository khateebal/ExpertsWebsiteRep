using ServerApp.Services.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Net;
using Microsoft.AspNetCore.HttpOverrides;
using AspNetCore.SEOHelper;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Net.Http.Headers;
using ServerApp.Route;
using ServerApp.Rules;
using ServerApp.Services.ViewExpander;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.ViewLocationFormats.Clear();
    options.ViewLocationFormats.Add("/ClientApp/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
    options.ViewLocationFormats.Add("/ClientApp/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
});

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);


//Ubunto 22.4 ------------------------------
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
});
builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));
//Ubunto 22.4------------------------------

//Compression
builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
});
//



var app = builder.Build();
if (!app.Environment.IsDevelopment())
{

    //Ubunto 22.4 ------------------------------
    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    });
    app.Urls.Add("http://+:5000");
    app.UseCors("AllowAll");
    //Ubunto 22.4 ------------------------------

    // Configure the HTTP request pipeline.
    // Configure the HTTP request pipeline.
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();

}
app.Use(async (ctx, next) =>
{
    await next();

    if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
    {
        //Re-execute the request so the user gets the error page
        string originalPath = ctx.Request.Path.Value;
        ctx.Items["originalPath"] = originalPath;
        ctx.Request.Path = "/Home/Error";
        await next();
    }
});
var options = new RewriteOptions();
options.Rules.Add(new NonWwwRule());
app.UseRewriter(options);


app.UseHttpsRedirection();
app.UseResponseCompression();
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=2592000";
    }
});

app.UseXMLSitemap(Directory.GetCurrentDirectory());
app.UseRobotsTxt(Directory.GetCurrentDirectory());
app.UseRouting();


#region Localization



RequestLocalizationOptions LocalizationOptions =
            new RequestLocalizationOptions()
            {
                SupportedCultures = new CultureInfo[] { new CultureInfo("en"), new CultureInfo("ar") }.ToList(),
                SupportedUICultures = new CultureInfo[] { new CultureInfo("en"), new CultureInfo("ar") }.ToList(),
                DefaultRequestCulture = new RequestCulture(new CultureInfo("en")),
                ApplyCurrentCultureToResponseHeaders = true
            };
// Cookie Localization first then Request Culture
var QueryCultureProvider = LocalizationOptions.RequestCultureProviders[0];

LocalizationOptions.RequestCultureProviders.RemoveAt(0);
LocalizationOptions.RequestCultureProviders.Insert(1, new RouteValueRequestCultureProvider() { Options = LocalizationOptions });


app.UseRequestLocalization(LocalizationOptions);

#endregion


app.MapControllerRoute(
    name: "cultureRoute",
    pattern: "{culture}/{controller}/{action}/{id?}",
    defaults: new { controller = "Home", action = "Index" },
    constraints: new
    {
        culture = new RegexRouteConstraint("^[a-z]{2}(?:-[A-Z]{2})?$")
    });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapRazorPages();

app.Run();
