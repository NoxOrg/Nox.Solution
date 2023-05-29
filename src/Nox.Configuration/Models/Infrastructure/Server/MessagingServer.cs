using Json.Schema.Generation;

namespace Nox
{ 
    public class MessagingServer : ServerBase
    {
        [Required]
        public MessagingServerProvider? Provider { get; set; }
    }
}
