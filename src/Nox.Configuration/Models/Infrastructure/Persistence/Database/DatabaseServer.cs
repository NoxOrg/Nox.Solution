using Json.Schema.Generation;


namespace Nox
{
    [AdditionalProperties(false)]
    public class DatabaseServer : ServerBase
    {
        [Required]
        public DatabaseServerProvider? Provider { get; set; }
    }
}
