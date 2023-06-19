namespace Nox.Solution;

public class IntegrationSourceHttpOptions
{
    public string Route { get; set; } = string.Empty;
    public IntegrationSourceHttpFormat ResponseFormat { get; set; } = IntegrationSourceHttpFormat.Json;
    public IntegrationSourceHttpVerb HttpVerb { get; set; } = IntegrationSourceHttpVerb.HttpGet;
}