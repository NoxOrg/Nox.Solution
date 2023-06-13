using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class BffServer: ServerBase
    {
        [Required]
        [AdditionalProperties(false)]
        public BffServerProvider Provider { get; internal set; } = BffServerProvider.Blazor;
    }
}