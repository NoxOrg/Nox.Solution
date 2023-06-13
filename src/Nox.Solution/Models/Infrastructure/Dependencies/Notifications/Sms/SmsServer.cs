using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class SmsServer: ServerBase
    {
        [Required]
        [AdditionalProperties(false)]
        public SmsServerProvider Provider { get; internal set; } = SmsServerProvider.ClickSend;
    }
}