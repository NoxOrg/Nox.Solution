using Json.Schema.Generation;

namespace Nox.Schedule;

[AdditionalProperties(false)]
public class ScheduleRetryPolicy
{
    public int? Limit { get; set; }
    public int? DelaySeconds { get; set; }
    public int? DoubleDelayLimit { get; set; }
}