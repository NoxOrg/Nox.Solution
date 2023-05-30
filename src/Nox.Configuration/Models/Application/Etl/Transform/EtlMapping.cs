using Json.Schema.Generation;

namespace Nox.Transform;

[AdditionalProperties(false)]
public class EtlMapping
{
    [Required]
    public string? SourceColumn { get; set; }

    public string? Converter { get; set; }
    
    [Required]
    public string? TargetAttribute { get; set; }
}