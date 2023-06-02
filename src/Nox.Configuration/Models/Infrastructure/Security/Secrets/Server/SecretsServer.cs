using Json.Schema.Generation;

namespace Nox;

[AdditionalProperties(false)]
public class SecretsServer: ServerBase
{
    public SecretsProvider? Provider { get; set; }
}