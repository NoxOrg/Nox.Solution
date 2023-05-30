using Json.Schema.Generation;
using System.Collections.Generic;
using static Humanizer.In;

namespace Nox
{
    [AdditionalProperties(false)]
    public class ServerBase
    {
        [Required]
        [Pattern(@"^[^\s]*$")]
        [Title("The unique name of this server component in the solution.")]
        [Description("The name of this server component in the solution. The name must be unique in the solution configuration")]
        public string? Name { get; set; }

        [Title("Hostname, IP address or URL.")]
        [Description("The name, address or IP of the server to connect to.")]
        public string? Server { get; set; }
        
        [Title("Server port")]
        [Description("The port to connect to.")]
        public int? Port { get; set; }
        
        [Title("Username.")]
        [Description("The username to use when connecting to this server.")]
        public string? User { get; set; }
        
        [Title("Password.")]
        [Description("The password to use when connecting to this server.")]
        public string? Password { get; set; }
        
        [Title("Additional options.")]
        [Description("A list of additional options to set when connecting to this server.")]
        public string? Options { get; set; }

    }
}
