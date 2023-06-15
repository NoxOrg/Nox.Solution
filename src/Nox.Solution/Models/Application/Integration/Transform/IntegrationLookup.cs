using Json.Schema.Generation;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class IntegrationLookup
    {
        [Required] 
        public string? SourceColumn { get; internal set; }

        [Required]
        [AdditionalProperties(false)]
        public IntegrationMatch Match { get; internal set; } = new();

        [Required] 
        public string TargetAttribute { get; internal set; } = string.Empty;
    }
}