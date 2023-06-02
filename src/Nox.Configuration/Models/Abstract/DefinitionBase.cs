using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Nox
{

    public abstract class DefinitionBase
    {

        [JsonPropertyName("$ref")] 
        public Uri? Ref { get; set; }

    }
}