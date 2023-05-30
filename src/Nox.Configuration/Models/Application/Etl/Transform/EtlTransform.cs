using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox.Transform;

[AdditionalProperties(false)]
public class EtlTransform
{
    [AdditionalProperties(false)]
    public List<EtlMapping>? Map { get; set; }
    
    [AdditionalProperties(false)]
    public List<EtlLookup>? Lookup { get; set; }
}