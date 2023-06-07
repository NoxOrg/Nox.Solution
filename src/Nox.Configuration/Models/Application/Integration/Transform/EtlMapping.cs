using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class EtlMapping
    {
        [Required] 
        public string? SourceColumn { get; set; }

        public EtlMappingConverter? Converter { get; set; }

        [Required] 
        public string? TargetAttribute { get; set; }
    }
}