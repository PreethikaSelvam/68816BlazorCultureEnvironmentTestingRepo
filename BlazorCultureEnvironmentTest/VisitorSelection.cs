using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Localization;

namespace BlazorCultureEnvironmentTest;

public sealed record VisitorSelection(string Culture, string Environment, string VisitorName)
{
    public static VisitorSelection FromRequest(HttpContext? context)
    {
        var culture = context?.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name ?? "en-US";
        var environment = context?.Request.Query["env"].FirstOrDefault() ?? "Development";
        var visitorName = context?.Request.Query["visitor"].FirstOrDefault() ?? "Anonymous";

        return new VisitorSelection(culture, environment, visitorName);
    }

    public void Apply(BrowserOptions options)
    {
        options.WebAssembly.ApplicationCulture = Culture;
        options.WebAssembly.EnvironmentName = Environment;
        options.WebAssembly.EnvironmentVariables["VISITOR_NAME"] = VisitorName;
        options.WebAssembly.EnvironmentVariables["FEATURE_BANNER"] =
            Environment.Equals("ValidationLab", StringComparison.OrdinalIgnoreCase) ? "enabled" : "disabled";
        options.WebAssembly.EnvironmentVariables["EMPTY_VALUE"] = "";
    }
}