using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class CacheServer : ServerBase
    {
        [Required]
        [AdditionalProperties(false)]
        public CacheServerProvider? Provider { get; internal set; }
    }
}