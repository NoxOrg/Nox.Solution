using Json.Schema.Generation;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class IntegrationMapping
    {
        [Required] 
        public string SourceColumn { get; internal set; } = string.Empty;

        public EtlMappingConverter? Converter { get; internal set; }

        [Required] 
        public string TargetAttribute { get; internal set; } = string.Empty;
    }
}