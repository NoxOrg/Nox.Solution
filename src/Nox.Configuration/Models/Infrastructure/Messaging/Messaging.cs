
using Json.Schema.Generation;

namespace Nox
{
    
    public class Messaging
    {
        [Required]
        public  MessagingServer? DomainEventServer { get; set; }

        [Required]
        public  MessagingServer? IntegrationEventServer { get; set; }
    }
}
