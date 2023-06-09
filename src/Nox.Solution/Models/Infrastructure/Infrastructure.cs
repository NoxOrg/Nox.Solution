using Json.Schema.Generation;

namespace Nox.Solution;
    [Title("A definition for infrastructure components used in a solution.")]
    [Description("A definition for the persistence, messaging and other pertinent components pertaining to solution infrastructure.")]
    [AdditionalProperties(false)]
    public class Infrastructure : DefinitionBase
    {
        [Required]
        [AdditionalProperties(false)]
        public Persistence Persistence { get; internal set; } = new();

        [Required]
        [AdditionalProperties(false)]
        public Messaging Messaging { get; internal set; } = new();
        

        [AdditionalProperties(false)]
        public Endpoints? Endpoints { get; internal set; }

        [AdditionalProperties(false)]
        public Dependencies? Dependencies { get; internal set; }
    }
