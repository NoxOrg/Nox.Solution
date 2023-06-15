using Json.Schema.Generation;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class IntegrationSchedule
    {
        [Required] 
        public string Start { get; internal set; } = string.Empty;

        [AdditionalProperties(false)] 
        public IntegrationScheduleRetryPolicy? Retry { get; internal set; }

        public bool? RunOnStartup { get; internal set; }
    }
}