using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Definition namespace for a Http ETL source.")]
    [Description("This section specified attributes related to an ETL source of type Http. Attributes include the route, format and verb.")]
    [AdditionalProperties(false)]
    public class IntegrationSourceHttpOptions
    {
        [Title("The Http request URI.")]
        [Description("The request URI for the Http ETL source.")]
        public string Route { get; set; } = string.Empty;

        [Title("The Http request format.")]
        [Description("The format of the Http response data papyload.")]
        public string Format { get; set; } = string.Empty;

        [Title("The Http request verb.")]
        [Description("The relevant verb detailing the Http request type, i.e. GET, PUT, etc.")]
        public string Verb { get; set; } = string.Empty;
    }
}
