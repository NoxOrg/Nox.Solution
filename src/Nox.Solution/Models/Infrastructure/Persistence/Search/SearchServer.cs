using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class SearchServer: ServerBase
    {
        [Required] public SearchServerProvider Provider { get; internal set; } = SearchServerProvider.ElasticSearch;
    }
}