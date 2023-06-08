using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class ImServer: ServerBase
    {
        [AdditionalProperties(false)]
        public ImServerProvider? Provider { get; internal set; }
    }
}