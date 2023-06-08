using Json.Schema.Generation;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class EtlLookup
    {
        [Required] 
        public string? SourceColumn { get; internal set; }

        [Required]
        [AdditionalProperties(false)] 
        public EtlMatch? Match { get; internal set; }

        [Required] 
        public string? TargetAttribute { get; internal set; }
    }
}