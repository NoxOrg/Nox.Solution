using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class ApiServer: ServerBase
    {
        [Required]
        [AdditionalProperties(false)]
        public ApiServerProvider Provider { get; internal set; } = ApiServerProvider.OData;
    }
}