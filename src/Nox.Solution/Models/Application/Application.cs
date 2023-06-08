using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class Application: DefinitionBase
    {
        [AdditionalProperties(false)] public IReadOnlyList<Integration>? Integration { get; internal set; }

        [AdditionalProperties(false)] public IReadOnlyList<DataTransferObject>? DataTransferObjects { get; internal set; }
    }
}