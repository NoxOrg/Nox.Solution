using Json.Schema.Generation;


namespace Nox
{
    public class DatabaseServer : ServerBase
    {
        [Required]
        public DatabaseServerProvider? Provider { get; set; }
    }
}
