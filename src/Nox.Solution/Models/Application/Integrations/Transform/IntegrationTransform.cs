using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class IntegrationTransform
    {
        [AdditionalProperties(false)] 
        public IReadOnlyList<IntegrationMapping>? Map { get; internal set; }

        [AdditionalProperties(false)] 
        public IReadOnlyList<IntegrationLookup>? Lookup { get; internal set; }
    }
}