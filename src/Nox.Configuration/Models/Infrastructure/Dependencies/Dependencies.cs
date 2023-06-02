using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class Dependencies
    {
        [AdditionalProperties(false)]
        public Translations? Translations { get; set; }
        
        [AdditionalProperties(false)]
        public List<DataConnection>? DataConnections { get; set; }
        
        [AdditionalProperties(false)]
        public Notifications? Notifications { get; set; }
        
        [AdditionalProperties(false)]
        public Monitoring? Monitoring { get; set; }
        
        [AdditionalProperties(false)]
        public Security? Security { get; set; }
    }
}