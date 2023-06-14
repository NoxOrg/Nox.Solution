using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class IntegrationMatch
    {
        [Required] 
        public string Table { get; internal set; } = string.Empty;

        [Required] 
        public string LookupColumn { get; internal set; } = string.Empty;

        [Required] 
        public string ReturnColumn { get; internal set; } = string.Empty;
    }
}