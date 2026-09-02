# Browser culture and environment validation

Sample used to validate [dotnet/aspnetcore#68816](https://github.com/dotnet/aspnetcore/issues/68816). It validates per-browser culture, environment name, and environment variables configured with `BrowserOptions.WebAssembly` and `<ConfigureBrowser>` in Interactive WebAssembly and Interactive Auto.

## Setup

The tested SDK was `11.0.100-preview.7.26381.103`.
The [tested repository revision](https://github.com/PreethikaSelvam/68816BlazorCultureEnvironmentTestingRepo/commit/dfc537dc1c0c7e0127718c05ad1c3992490193c7) was `dfc537dc1c0c7e0127718c05ad1c3992490193c7`.

```powershell
dotnet build .\BlazorCultureEnvironmentTest.sln
dotnet run --project .\BlazorCultureEnvironmentTest\BlazorCultureEnvironmentTest.csproj --launch-profile https
```

| Route | Mode |
| --- | --- |
| `/wasm-validation` | Interactive WebAssembly |
| `/auto-validation` | Interactive Auto |

Open the app at <https://localhost:7036/>.

## Browser configuration

Set the WebAssembly environment and visitor name through the query string:

```text
https://localhost:7036/wasm-validation?env=ValidationLab&visitor=Alice
https://localhost:7036/auto-validation?env=ValidationLab&visitor=Alice
```

The app passes `VISITOR_NAME`, `FEATURE_BANNER`, and an empty `EMPTY_VALUE` to WebAssembly. Use the page buttons to test `en-US`, `fr-FR`, and `es-ES`. Spanish has no app translation and validates resource fallback with Spanish formatting.

## Evidence

- SDK, runtime, and build output: [`Evidence/Build`](Evidence/Build)
- Screenshots and videos: [`Evidence/TestCasesAndOutput`](Evidence/TestCasesAndOutput)
- Manual browser and server diagnostics: [`Evidence/ManualLogs`](Evidence/ManualLogs)
- Full test report: [`BrowserCultureAndEvironmentValidationReport.docx`](Evidence/BrowserCultureAndEvironmentValidationReport.docx)

## Recorded test environment

- Operating system: Windows 11 24H2 x64 (build 26100.9106)
- .NET SDK: `11.0.100-preview.7.26381.103`
- ASP.NET Core runtime: `11.0.0-preview.7.26381.103`
- Browsers: Google Chrome and Microsoft Edge
- Visual Studio Code `1.135.0`
