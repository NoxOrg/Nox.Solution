using Json.Schema.Generation;
using System.Collections.Generic;

namespace Nox.Solution
{
    public class ObjectTypeOptions : DefinitionBase 
    {
        [Required]
        public List<NoxSimpleTypeDefinition>? Attributes { get; internal set; }
    }
}