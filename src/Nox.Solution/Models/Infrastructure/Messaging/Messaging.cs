
using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class Messaging
    {
        [Required]
        [AdditionalProperties(false)]
        public MessagingServer IntegrationEventServer { get; internal set; } = new();
    }
}
