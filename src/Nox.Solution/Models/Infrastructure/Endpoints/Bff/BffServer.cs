using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class BffServer: ServerBase
    {
        [Required]
        [Title("The BFF server provider.")]
        [Description("The provider used for this BFF (Backend for Frontend) server. Examples include Blazor.")]
        [AdditionalProperties(false)]
        public BffServerProvider Provider { get; internal set; } = BffServerProvider.Blazor;
    }
}