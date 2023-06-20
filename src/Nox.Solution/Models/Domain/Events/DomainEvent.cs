using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox.Solution;

[Title("Defines a domain event")]
[Description("The declaration of a domain event and its attributes. See https://noxorg.dev for more.")]
[AdditionalProperties(false)]
public class DomainEvent
{
    [Required]
    [Title("The name of the domain event. Contains no spaces.")]
    [Description("The name of the domain event. It should be a commonly used singular noun and be unique within a solution.")]
    [Pattern(@"^[^\s]*$")]
    public string Name { get; internal set; } = string.Empty;

    [Title("A phrase describing the domain event.")]
    [Description("A description of the domain event and what it represents in the real world.")]
    public string? Description { get; internal set; }
    
    [Title("Attributes that describe this event.")]
    [Description("Define one or more attribute(s) that describes the composition of this domain event.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<NoxSimpleTypeDefinition>? Attributes { get; internal set; }
}