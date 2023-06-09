using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class EmailServer: ServerBase
    {
        [Required]
        [AdditionalProperties(false)]
        public EmailServerProvider Provider { get; internal set; } = EmailServerProvider.SendGrid;
    }
}