using Json.Schema.Generation;


namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class DatabaseServer : ServerBase
    {
        [Required]
        public DatabaseServerProvider? Provider { get; internal set; }
    }
}
