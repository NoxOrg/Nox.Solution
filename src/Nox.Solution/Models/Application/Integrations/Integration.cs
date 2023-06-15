using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class Integration
    {
        [Required]
        [Title("The name of the etl. Contains no spaces.")]
        [Description("The name of the etl. It should be a commonly used singular noun and be unique within a solution.")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; set; } = string.Empty;

        [Title("A phrase describing the etl.")]
        [Description("A description of the etl.")]
        public string? Description { get; set; }

        [AdditionalProperties(false)] public IntegrationSource? Source { get; internal set; }

        [AdditionalProperties(false)] public IntegrationTransform? Transform { get; internal set; }

        [AdditionalProperties(false)] public IntegrationTarget? Target { get; internal set; }
    }
}