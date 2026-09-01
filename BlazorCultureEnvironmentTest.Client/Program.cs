using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorCultureEnvironmentTest.Client.Validation;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddLocalization();
builder.Services.AddSingleton(new VisitorRuntimeSettings(
	builder.HostEnvironment.Environment,
	builder.Configuration["VISITOR_NAME"],
	builder.Configuration["FEATURE_BANNER"],
	builder.Configuration["EMPTY_VALUE"],
	"WebAssembly"));

await builder.Build().RunAsync();
