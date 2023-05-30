using Json.Schema.Generation;

namespace Nox
{
    public class EmailServer: ServerBase
    {
        [Required]
        public EmailServerProvider? Provider { get; set; }
    }
}