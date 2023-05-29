using System;
using System.Text.Json.Serialization;

namespace Nox
{

    public abstract class DefinitionBase
    {

        [JsonPropertyName("$ref")]
        public Uri? Ref { get; set; }

    }
}