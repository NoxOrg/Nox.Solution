using System.Collections.Generic;
using Json.Schema.Generation;
using Nox.Transform;

namespace Nox;

[AdditionalProperties(false)]
public class Etl
{
    [Required]
    [Title("The name of the etl. Contains no spaces.")]
    [Description("The name of the etl. It should be a commonly used singular noun and be unique within a solution.")]
    [Pattern(@"^[^\s]*$")]
    public string Name { get; set; } = string.Empty;
    
    [Title("A phrase describing the etl.")]
    [Description("A description of the etl.")]
    public string? Description { get; set; }

    [AdditionalProperties(false)]
    public EtlSource? Source { get; set; }

    [AdditionalProperties(false)]
    public List<EtlTransform>? Transform { get; set; }

    [AdditionalProperties(false)]
    public EtlTarget? Target { get; set; }
}