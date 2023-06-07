using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class SmsServer: ServerBase
    {
        [AdditionalProperties(false)]
        public SmsServerProvider? Provider { get; internal set; }
    }
}