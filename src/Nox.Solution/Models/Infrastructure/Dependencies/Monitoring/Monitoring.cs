using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class Monitoring: ServerBase
    {
        [Required]
        [AdditionalProperties(false)]
        public MonitoringProvider Provider { get; internal set; } = MonitoringProvider.ElasticApm;
    }
}