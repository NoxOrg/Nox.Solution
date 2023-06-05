using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class EtlMatch
    {
        [Required] public string? Table { get; set; }

        [Required] public string? LookupColumn { get; set; }

        [Required] public string? ReturnColumn { get; set; }
    }
}