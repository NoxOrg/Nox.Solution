using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class Application: DefinitionBase
    {
        [AdditionalProperties(false)] public List<Integration>? Integration { get; internal set; }

        [AdditionalProperties(false)] public List<DataTransferObject>? DataTransferObjects { get; internal set; }
    }
}