using Json.Schema.Generation;

namespace Nox
{
    [AdditionalProperties(false)]
    public class ServiceBase
    {
        [Required]
        [Pattern(@"^[^\s]*$")]
        [Title("The unique name of this service component in the solution.")]
        [Description("The name of this service component in the solution. The name must be unique in the solution configuration")]
        public string? Name { get; set; }
        
        [Title("Hostname, IP address or URL.")]
        [Description("The name, address or IP of the server to connect to.")]
        public string? Server { get; set; }
        
        [Title("Http port number")]
        [Description("The port number to use when establishing an HTTP connection to this server.")]
        public int? HttpPort { get; set; }
        
        [Title("Https port number")]
        [Description("The port number to use when establishing an HTTPS connection to this server.")]
        public int? HttpsPort { get; set; }
    }
}