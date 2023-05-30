
using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class Persistence
    {
        [Required]
        [AdditionalProperties(false)]
        public DatabaseServer? DatabaseServer { get; set; }
        
        [AdditionalProperties(false)]
        public CacheServer? CacheServer { get; set; }

        [AdditionalProperties(false)]
        public SearchServer? SearchServer { get; set; }

        [AdditionalProperties(false)]
        public EventSourceServer? EventSourceServer { get; set; }
    }
}
