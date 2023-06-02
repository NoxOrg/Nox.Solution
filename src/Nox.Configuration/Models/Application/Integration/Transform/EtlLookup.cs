using Json.Schema.Generation;

namespace Nox.Transform;

[AdditionalProperties(false)]
public class EtlLookup
{
    [Required]
    public string? SourceColumn { get; set; }

    [AdditionalProperties(false)]
    public EtlMatch? Match { get; set; }
    
    [Required]
    public string? TargetAttribute { get; set; }
}