using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Definition namespace for attributes describing the target component of an ETL integration.")]
    [Description("This section details ETL target attributes like name, description and type among other.")]
    [AdditionalProperties(false)]
    public class IntegrationTarget
    {
        [Required]
        [Title("The name of the ETL target. Contains no spaces.")]
        [Description("The name of the ETL target. It should be a commonly used singular noun and be unique within a solution.")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; internal set; } = string.Empty;

        [Title("The description of the ETL target.")]
        [Description("A phrase describing the ETL target.")]
        public string? Description { get; internal set; }

        [Required]
        [Title("The type of target.")]
        [Description("Specify the type of target. Options include entity, database, file, webAPI and message queue.")]
        public EtlTargetType TargetType { get; internal set; } = EtlTargetType.Database;

        [Title("The name of the ETL target data connection. Contains no spaces.")]
        [Description("The name should be a commonly used singular noun and be unique within a solution.")]
        [Pattern(@"^[^\s]*$")]
        [AdditionalProperties(false)]
        public string? DataConnection { get; internal set; }
    }
}