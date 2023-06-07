using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class SecretsServer : ServerBase
    {
        public SecretsServerProvider? Provider { get; internal set; }
    }
}