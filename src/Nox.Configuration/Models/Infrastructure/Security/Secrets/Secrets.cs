using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class Secrets
    {
        [AdditionalProperties(false)] public SecretsServer? SecretsServer { get; internal set; }

        [AdditionalProperties(false)] public SecretsValidFor? ValidFor { get; internal set; }
    }
}