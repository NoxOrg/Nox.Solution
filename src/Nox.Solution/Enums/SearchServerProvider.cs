using System;
using System.Linq;

namespace Nox
{
    public enum SearchServerProvider
    {
        // apacheSoir,
        // amazonCloudSearch,
        // algolia,
        ElasticSearch
    }
    
    public static class SearchServerProviderHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(SearchServerProvider))
                .Cast<SearchServerProvider>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}