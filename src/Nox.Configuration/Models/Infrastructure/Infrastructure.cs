using Json.Schema.Generation;

namespace Nox
{

    [Title("A definition for infrastructure components used in a solution.")]
    [Description("A definition for the persistence, messaging and other pertinent components pertaining to solution infrastructure.")]
    [AdditionalProperties(false)]
    public class Infrastructure : DefinitionBase
    {

        [Required]
        [AdditionalProperties(false)]
        public Messaging? Messaging { get; set; }


        [Required]
        [AdditionalProperties(false)]
        public Persistence? Persistence { get; set; }

        [AdditionalProperties(false)]
        public Services? Services { get; set; }

        [AdditionalProperties(false)]
        public Dependencies? Type { get; set; }
    }
}