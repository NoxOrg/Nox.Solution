using Json.Schema.Generation;

namespace Nox.Solution;

public class IntegrationSourceMessageQueueOptions
{
    [Required] 
    [Title("The source name.")]
    [Description("The name of the queue, topic or subscription from which messages will be consumed.")]
    public string Source { get; set; } = string.Empty;
}