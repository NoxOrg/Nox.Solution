using Json.Schema.Generation;
using System.Collections.Generic;

namespace Nox
{
    public class ObjectTypeOptions : DefinitionBase 
    {
        [Required]
        public List<NoxSimpleTypeDefinition>? Attributes { get; set; }
    }
}