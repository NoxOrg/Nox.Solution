using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class ApiServer: ServerBase
    {
        [Required]
        [Title("The API server provider.")]
        [Description("The provider used for this API server. Examples include OData, gRPC, GraphQL and others.")]
        [AdditionalProperties(false)]
        public ApiServerProvider Provider { get; internal set; } = ApiServerProvider.OData;
    }
}