using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class EtlTransform
    {
        [AdditionalProperties(false)] 
        public IReadOnlyList<EtlMapping>? Map { get; internal set; }

        [AdditionalProperties(false)] 
        public IReadOnlyList<EtlLookup>? Lookup { get; internal set; }
    }
}