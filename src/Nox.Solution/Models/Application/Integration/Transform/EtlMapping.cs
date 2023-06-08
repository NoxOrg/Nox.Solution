using Json.Schema.Generation;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class EtlMapping
    {
        [Required] 
        public string? SourceColumn { get; internal set; }

        public EtlMappingConverter? Converter { get; internal set; }

        [Required] 
        public string? TargetAttribute { get; internal set; }
    }
}