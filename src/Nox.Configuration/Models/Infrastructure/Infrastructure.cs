using Json.Schema.Generation;

namespace Nox
{

    [AdditionalProperties(false)]
    public class Infrastructure : DefinitionBase
    {

        [Required]
        [AdditionalProperties(false)]
        public Messaging? Messaging { get; set; }


        [Required]
        [AdditionalProperties(false)]
        public Persistence? Persistence { get; set; }
    }
}