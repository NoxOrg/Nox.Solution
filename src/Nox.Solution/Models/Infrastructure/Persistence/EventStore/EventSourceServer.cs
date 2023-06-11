using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class EventSourceServer: ServerBase
    {
        [Required]
        [Title("The event source server provider.")]
        [Description("The provider used for this event source server. Examples include EventStoreDB.")]
        public EventSourceServerProvider Provider { get; internal set; } = EventSourceServerProvider.EventStoreDb;
    }
}