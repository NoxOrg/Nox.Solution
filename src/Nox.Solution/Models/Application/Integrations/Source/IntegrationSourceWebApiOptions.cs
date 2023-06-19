namespace Nox.Solution;

public class IntegrationSourceWebApiOptions
{
    public string Route { get; set; } = string.Empty;
    public IntegrationWebApiRequestResponseFormat ResponseFormat { get; set; } = IntegrationWebApiRequestResponseFormat.Json;
    public IntegrationSourceHttpVerb HttpVerb { get; set; } = IntegrationSourceHttpVerb.HttpGet;
}