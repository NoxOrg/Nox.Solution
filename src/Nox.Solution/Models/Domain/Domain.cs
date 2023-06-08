using Json.Schema.Generation;
using System.Collections.Generic;

namespace Nox
{

    [Title("Information about the domain including entities and their relationships")]
    [Description("Contains definitions of entities, their attributes, events, commands and queries.")]
    [AdditionalProperties(false)]
    public class Domain : DefinitionBase
    {

        [Required]
        [Title("The entities that describe the domain.")]
        [Description("The collection of entities and their relationship(s) with each other.")]
        [AdditionalProperties(false)]
        public List<Entity>? Entities { get; internal set; }

    }
}