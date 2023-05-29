using Json.Schema.Generation;

namespace Nox
{
    public class EventSourceServer: ServerBase
    {
        [Required]
        public EventSourceServerProvider? Provider { get; set; }
    }
}