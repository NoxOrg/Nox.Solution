
using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class Persistence
    {
        [Required]
        [AdditionalProperties(false)]
        public DatabaseServer? DatabaseServer { get; internal set; }
        
        [AdditionalProperties(false)]
        public CacheServer? CacheServer { get; internal set; }

        [AdditionalProperties(false)]
        public SearchServer? SearchServer { get; internal set; }

        [AdditionalProperties(false)]
        public EventSourceServer? EventSourceServer { get; internal set; }
    }
}
