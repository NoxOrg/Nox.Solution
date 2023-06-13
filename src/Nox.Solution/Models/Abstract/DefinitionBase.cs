using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Nox.Solution
{

    public abstract class DefinitionBase
    {

        [JsonPropertyName("$ref")] 
        public Uri? Ref { get; set; }
        
    }
}