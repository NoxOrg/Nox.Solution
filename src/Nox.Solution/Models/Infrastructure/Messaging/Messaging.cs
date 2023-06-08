
using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class Messaging
    {
        //removed this as we will always create a domain event server internally using MassTransit Mediator
        // [Required]
        // [AdditionalProperties(false)]
        // public  MessagingServer? DomainEventServer { get; internal set; }

        [Required]
        [AdditionalProperties(false)]
        public  MessagingServer? IntegrationEventServer { get; internal set; }
    }
}
