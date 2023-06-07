using System;
using System.Linq;

namespace Nox
{
    public enum CacheServerProvider
    {
        AmazonElasticCache,
        AzureRedis,
        Memcached,
        Redis
    }
    
    public static class CacheServerProviderHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(CacheServerProvider))
                .Cast<CacheServerProvider>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}