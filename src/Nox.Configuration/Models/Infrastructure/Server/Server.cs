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
        public string? Name { get; set; }

        public string? server { get; set; }
        public int? port { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
        public string? Options { get; set; }

    }
}
