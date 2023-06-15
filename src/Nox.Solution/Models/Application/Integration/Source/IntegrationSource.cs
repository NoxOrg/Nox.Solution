using Json.Schema.Generation;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class IntegrationSource
    {
        [Required]
        [Title("The name of the integration source. Contains no spaces.")]
        [Description("The name of the data connection for this integration source. This must refer to an existing data connection in infrastructure, dependencies, dataConnections.")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; internal set; } = string.Empty;

        [Title("A phrase describing the etl source.")]
        [Description("A description of the etl source.")]
        public string? Description { get; internal set; }

        [AdditionalProperties(false)] 
        public IntegrationSchedule? Schedule { get; internal set; }

        [AdditionalProperties(false)] 
        public IntegrationSourceDatabaseWatermark? Watermark { get; internal set; }

        [AdditionalProperties(false)] 
        public IntegrationSourceDatabaseOptions? DatabaseOptions { get; set; }

        [AdditionalProperties(false)] 
        public IntegrationSourceFileOptions? FileOptions { get; set; }

        [AdditionalProperties(false)] 
        public IntegrationSourceMessageQueueOptions? MessageQueueOptions { get; set; }

        [AdditionalProperties(false)] 
        public IntegrationSourceHttpOptions? HttpOptions { get; set; }
        
    }
}