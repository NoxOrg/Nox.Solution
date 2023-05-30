using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class Dependencies
    {
        [AdditionalProperties(false)]
        public TranslationService? TranslationService { get; set; }
        
        [AdditionalProperties(false)]
        public List<DataConnection>? DataConnections { get; set; }
        
        [AdditionalProperties(false)]
        public NotificationServices? NotificationServices { get; set; }
        
        [AdditionalProperties(false)]
        public Observability? Observability { get; set; }
        
        [AdditionalProperties(false)]
        public Security? Security { get; set; }
    }
}