using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class Dependencies
    {
        [AdditionalProperties(false)]
        public Translations? Translations { get; internal set; }
        
        [AdditionalProperties(false)]
        public IReadOnlyList<DataConnection>? DataConnections { get; internal set; }
        
        [AdditionalProperties(false)]
        public Notifications? Notifications { get; internal set; }
        
        [AdditionalProperties(false)]
        public Monitoring? Monitoring { get; internal set; }
        
        [AdditionalProperties(false)]
        public Security? Security { get; internal set; }
    }
}