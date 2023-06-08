using Json.Schema.Generation;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class EtlSchedule
    {
        [Required] 
        public string? Start { get; internal set; }

        [AdditionalProperties(false)] 
        public ScheduleRetryPolicy? Retry { get; internal set; }

        public bool? RunOnStartup { get; internal set; }
    }
}