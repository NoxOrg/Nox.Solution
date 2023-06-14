using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class CacheServer : ServerBase
    {
        [Required]
        [Title("The cache server provider.")]
        [Description("The provider used for this cache server. Examples include AmazonElasticCache, AzureRedis, Memcached and Redis.")]
        [AdditionalProperties(false)]
        public CacheServerProvider Provider { get; internal set; } = CacheServerProvider.Memcached;
    }
}