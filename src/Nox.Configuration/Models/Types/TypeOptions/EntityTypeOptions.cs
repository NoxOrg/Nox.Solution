using Json.Schema.Generation;
using System.Collections.Generic;

namespace Nox
{
    public class EntityTypeOptions : DefinitionBase
    {
        [Required]
        public string? Entity { get; set; }
    }
}