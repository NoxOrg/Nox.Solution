
using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class Messaging
    {
        [Required]
        [AdditionalProperties(false)]
        public  MessagingServer? DomainEventServer { get; internal set; }

        [Required]
        [AdditionalProperties(false)]
        public  MessagingServer? IntegrationEventServer { get; internal set; }
    }
}
