using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class Notifications
    {
        [AdditionalProperties(false)]
        public EmailServer? EmailServer { get; internal set; }
        
        [AdditionalProperties(false)]
        public SmsServer? SmsServer { get; internal set; }
        
        [AdditionalProperties(false)]
        public ImServer? ImServer { get; internal set; }
    }
}