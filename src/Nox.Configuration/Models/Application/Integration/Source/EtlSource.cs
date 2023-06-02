using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class EtlSource
    {
        [Required]
        [Title("The name of the etl source. Contains no spaces.")]
        [Description("The name of the etl source. It should be a commonly used singular noun and be unique within a solution.")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; set; } = string.Empty;

        [Title("A phrase describing the etl source.")]
        [Description("A description of the etl source.")]
        public string? Description { get; set; }

        [AdditionalProperties(false)] public EtlSchedule? Schedule { get; set; }

        [Required]
        [AdditionalProperties(false)]
        public string? DataConnection { get; set; }

        [AdditionalProperties(false)] public DatabaseWatermark? Watermark { get; set; }
    }
}