using Json.Schema.Generation;

namespace Nox
{
    public class SearchServer: ServerBase
    {
        [Required]
        public SearchServerProvider? Provider { get; set; }
    }
}