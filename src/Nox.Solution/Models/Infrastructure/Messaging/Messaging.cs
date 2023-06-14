
using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class Messaging
    {
        [Required]
        [Title("Details pertaining to the IntegrationEventServer settings in a Nox solution.")]
        [Description("Defines settings pertinent to an IntegrationEventServer here. These include provider (RabbitMQ, Azure ServiceBus, Amazon SQS etc), connection details as well as internal default deployment settings.")]
        [AdditionalProperties(false)]
        public MessagingServer IntegrationEventServer { get; internal set; } = new();
    }
}
