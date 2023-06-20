using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox.Solution;

[Title("Defines an application event")]
[Description("The declaration of an application event and its attributes. See https://noxorg.dev for more.")]
[AdditionalProperties(false)]
public class ApplicationEvent
{
    [Required]
    [Title("The name of the application event. Contains no spaces.")]
    [Description("The name of the application event. It should be a commonly used singular noun and be unique within a solution.")]
    [Pattern(@"^[^\s]*$")]
    public string Name { get; internal set; } = string.Empty;

    [Title("A phrase describing the application event.")]
    [Description("A description of the application event and what it represents in the real world.")]
    public string? Description { get; internal set; }
    
    [Title("Attributes that describe this event.")]
    [Description("Define one or more attribute(s) that describes the composition of this application event.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<NoxSimpleTypeDefinition>? Attributes { get; internal set; }
}