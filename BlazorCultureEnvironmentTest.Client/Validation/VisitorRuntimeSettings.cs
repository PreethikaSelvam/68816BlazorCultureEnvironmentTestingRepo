namespace BlazorCultureEnvironmentTest.Client.Validation;

public sealed record VisitorRuntimeSettings(
    string EnvironmentName,
    string? VisitorName,
    string? FeatureBanner,
    string? EmptyValue,
    string Runtime);