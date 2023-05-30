using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class SearchServer: ServerBase
    {
        [Required]
        public SearchServerProvider? Provider { get; set; }
    }
}