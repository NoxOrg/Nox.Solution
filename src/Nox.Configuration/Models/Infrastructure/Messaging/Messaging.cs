
using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class Messaging
    {
        [Required]
        [AdditionalProperties(false)]
        public  MessagingServer? DomainEventServer { get; set; }

        [Required]
        [AdditionalProperties(false)]
        public  MessagingServer? IntegrationEventServer { get; set; }
    }
}
