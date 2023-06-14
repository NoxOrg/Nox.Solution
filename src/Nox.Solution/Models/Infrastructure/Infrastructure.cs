using Json.Schema.Generation;

namespace Nox.Solution;
    [Title("The definition namespace for infrastructure components pertaining to a Nox solution.")]
    [Description("Define components pertinent to solution infrastructure here. Examples include persistence, messaging, dependencies and endpoints.")]
    [AdditionalProperties(false)]
    public class Infrastructure : DefinitionBase
    {
        [Required]
        [Title("The definition namespace for persistance settings pertaining to a Nox solution.")]
        [Description("Defines settings pertinent to solution persistence here. These include database, event source, search and cache servers.")]
        [AdditionalProperties(false)]
        public Persistence Persistence { get; internal set; } = new();

        [Required]
        [Title("The definition namespace for messaging settings pertaining to a Nox solution.")]
        [Description("Defines settings pertinent to solution messaging here. These include IntegrationEventServer provider (RabbitMQ, Azure ServiceBus, Amazon SQS etc) and additional server connection details.")]
        [AdditionalProperties(false)]
        public Messaging Messaging { get; internal set; } = new();
        

        [AdditionalProperties(false)]
        [Title("The definition namespace for default endpoints pertaining to a Nox solution.")]
        [Description("Define default endpoints pertinent to a Nox solution here. These include endpoints for API and BFF servers.")]
        public Endpoints? Endpoints { get; internal set; }

        [AdditionalProperties(false)]
        public Dependencies? Dependencies { get; internal set; }
    }
