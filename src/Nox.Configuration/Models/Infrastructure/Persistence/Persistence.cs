
using Json.Schema.Generation;

namespace Nox
{
    public class Persistence
    {
        [Required]
        public DatabaseServer? DatabaseServer { get; set; }
        
        public CacheServer? CacheServer { get; set; }

        public SearchServer? SearchServer { get; set; }

        public EventSourceServer? EventSourceServer { get; set; }
    }
}
