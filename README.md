# Browser culture and environment validation

Sample used to validate per-browser culture, environment name, and environment variables configured with `BrowserOptions.WebAssembly` and `<ConfigureBrowser>`. The test covered Interactive WebAssembly and Interactive Auto. All 10 test cases passed.

## Setup

The tested SDK was `11.0.100-preview.7.26381.103`.

```powershell
dotnet build .\BlazorCultureEnvironmentTest.sln
dotnet run --project .\BlazorCultureEnvironmentTest\BlazorCultureEnvironmentTest.csproj --launch-profile http
```

| Route | Mode |
| --- | --- |
| `/wasm-validation` | Interactive WebAssembly |
| `/auto-validation` | Interactive Auto |

Open the app at <http://localhost:5117/>.

## Browser configuration

Set the WebAssembly environment and visitor name through the query string:

```text
http://localhost:5117/wasm-validation?env=ValidationLab&visitor=Alice
http://localhost:5117/auto-validation?env=ValidationLab&visitor=Alice
```

The app passes `VISITOR_NAME`, `FEATURE_BANNER`, and an empty `EMPTY_VALUE` to WebAssembly. Use the page buttons to test `en-US`, `fr-FR`, and `es-ES`. Spanish has no app translation and validates resource fallback with Spanish formatting.

## Evidence

- SDK, runtime, and build output: [`Evidence/Build`](Evidence/Build)
- Screenshots and videos: [`Evidence/TestCasesAndOutput`](Evidence/TestCasesAndOutput)
- Full test report: [`BrowserCultureAndEvironmentValidationReport.md`](Evidence/BrowserCultureAndEvironmentValidationReport.docx)

## Recorded test environment

- Operating system: Windows 11 x64
- .NET SDK: `11.0.100-preview.7.26381.103`
- ASP.NET Core runtime: `11.0.0-preview.7.26381.103`
- Browsers: Google Chrome and Microsoft Edge
- Visual Studio Code `1.134.0`
