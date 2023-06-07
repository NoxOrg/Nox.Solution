using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class EventSourceServer: ServerBase
    {
        [Required]
        public EventSourceServerProvider? Provider { get; internal set; }
    }
}