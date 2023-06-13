using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class Application: DefinitionBase
    {
        [AdditionalProperties(false)] public IReadOnlyList<Integration>? Integrations { get; internal set; }

        [AdditionalProperties(false)] public IReadOnlyList<DataTransferObject>? DataTransferObjects { get; internal set; }
    }
}