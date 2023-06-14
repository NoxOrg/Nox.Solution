using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class SearchServer: ServerBase
    {
        [Required]
        [Title("The search server provider.")]
        [Description("The provider used for this search server server. Examples include ElasticSearch.")]
        public SearchServerProvider Provider { get; internal set; } = SearchServerProvider.ElasticSearch;
    }
}