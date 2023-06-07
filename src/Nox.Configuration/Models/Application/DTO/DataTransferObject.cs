using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class DataTransferObject
    {
        [Required]
        [Title("The name of the dto. Contains no spaces.")]
        [Description("The name of the dto. It should be a commonly used singular noun and be unique within a solution.")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; set; } = string.Empty;

        [Title("A phrase describing the dto.")]
        [Description("A description of the dto and what it represents in the real world.")]
        public string? Description { get; set; }

        [Required]
        [AdditionalProperties(false)] 
        public List<NoxSimpleTypeDefinition>? Attributes { get; set; }
    }
}