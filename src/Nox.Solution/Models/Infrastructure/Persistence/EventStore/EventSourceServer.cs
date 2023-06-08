using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class EventSourceServer: ServerBase
    {
        [Required]
        public EventSourceServerProvider? Provider { get; internal set; }
    }
}