using Json.Schema.Generation;

namespace Nox
{ 
    [AdditionalProperties(false)]
    public class MessagingServer : ServerBase
    {
        [Required]
        [AdditionalProperties(false)]
        public MessagingServerProvider? Provider { get; set; }
    }
}
