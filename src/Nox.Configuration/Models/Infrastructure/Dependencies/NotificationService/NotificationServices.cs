using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class NotificationServices
    {
        [AdditionalProperties(false)]
        public EmailServer? EmailServer { get; set; }
        
        [AdditionalProperties(false)]
        public SmsServer? SmsServer { get; set; }
        
        [AdditionalProperties(false)]
        public ImServer? ImServer { get; set; }
    }
}