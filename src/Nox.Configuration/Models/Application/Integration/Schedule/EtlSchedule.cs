using Json.Schema.Generation;

namespace Nox.Schedule;

[AdditionalProperties(false)]
public class EtlSchedule
{
    [Required]
    public string? Start { get; set; }
    
    [AdditionalProperties(false)]
    public ScheduleRetryPolicy? Retry { get; set; }

    public bool? RunOnStartup { get; set; }
}