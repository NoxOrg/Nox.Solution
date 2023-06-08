using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class EtlMatch
    {
        [Required] 
        public string? Table { get; internal set; }

        [Required] 
        public string? LookupColumn { get; internal set; }

        [Required] 
        public string? ReturnColumn { get; internal set; }
    }
}