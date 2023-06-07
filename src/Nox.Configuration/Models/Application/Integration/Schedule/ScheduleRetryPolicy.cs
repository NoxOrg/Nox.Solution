using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class ScheduleRetryPolicy
    {
        public int? Limit { get; internal set; }
        public int? DelaySeconds { get; internal set; }
        public int? DoubleDelayLimit { get; internal set; }
    }
}