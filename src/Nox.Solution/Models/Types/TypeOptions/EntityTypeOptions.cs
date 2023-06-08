using Json.Schema.Generation;
using System.Collections.Generic;

namespace Nox.Solution
{
    public class EntityTypeOptions : DefinitionBase
    {
        [Required]
        public string? Entity { get; internal set; }
    }
}