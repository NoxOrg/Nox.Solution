using Json.Schema.Generation;
using System.Collections.Generic;

namespace Nox
{
    [Title("Defines a command tht operates on the domain.")]
    [Description("Defines a command that operates on the domain. Commands have side effects and doesn't return a value.")]
    [AdditionalProperties(false)]
    public class DomainCommand : NoxComplexTypeDefinition
    {
        public List<string>? EmitEvents { get; set; }
    }
}