using Json.Schema.Generation;

namespace Nox
{
    public class CacheServer : ServerBase
    {
        [Required]
        public CacheServerProvider? Provider { get; set; }
    }
}