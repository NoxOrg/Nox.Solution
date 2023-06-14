using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Definition namespace for attributes describing the source component of an ETL integration.")]
    [Description("This section details ETL source attributes like name, description, scheduling and watermark specifications.")]
    [AdditionalProperties(false)]
    public class EtlSource
    {
        [Required]
        [Title("The name of the ETL source. Contains no spaces.")]
        [Description("The name should be a commonly used singular noun and be unique within a solution.")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; internal set; } = string.Empty;

        [Title("A description of the ETL source.")]
        [Description("A phrase describing the source component of the ETL. Think about describing the what/where of this data source.")]
        public string? Description { get; internal set; }

        public EtlSchedule? Schedule { get; internal set; }

        [Required]
        [Title("The name of the ETL source data connection. Contains no spaces.")]
        [Description("The name should be a commonly used singular noun and be unique within a solution.")]
        [Pattern(@"^[^\s]*$")]
        [AdditionalProperties(false)]
        public string DataConnection { get; internal set; } = string.Empty;

        public DatabaseWatermark? Watermark { get; internal set; }
    }
}