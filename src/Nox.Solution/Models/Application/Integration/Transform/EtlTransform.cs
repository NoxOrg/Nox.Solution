using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class EtlTransform
    {
        [AdditionalProperties(false)] 
        public List<EtlMapping>? Map { get; internal set; }

        [AdditionalProperties(false)] 
        public List<EtlLookup>? Lookup { get; internal set; }
    }
}