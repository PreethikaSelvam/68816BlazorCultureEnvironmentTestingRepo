using BlazorCultureEnvironmentTest;
using BlazorCultureEnvironmentTest.Client.Validation;
using BlazorCultureEnvironmentTest.Components;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddScoped(_ => new VisitorRuntimeSettings("", null, null, null, "Server"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.MapStaticAssets();
app.UseRequestLocalization(new RequestLocalizationOptions()
    .SetDefaultCulture("en-US")
    .AddSupportedCultures("en-US", "fr-FR", "es-ES")
    .AddSupportedUICultures("en-US", "fr-FR", "es-ES"));

app.MapGet("/preferences/culture", (HttpContext context, string value, string? returnUrl) =>
{
    context.Response.Cookies.Append(
        CookieRequestCultureProvider.DefaultCookieName,
        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(value, value)));

    return Results.LocalRedirect(string.IsNullOrWhiteSpace(returnUrl) ? "/wasm-validation" : returnUrl);
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorCultureEnvironmentTest.Client._Imports).Assembly);

app.Run();
