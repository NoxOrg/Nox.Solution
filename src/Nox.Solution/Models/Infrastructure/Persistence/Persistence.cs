
using Json.Schema.Generation;

namespace Nox.Solution
{
    [AdditionalProperties(false)]
    public class Persistence
    {
        [Required]
        [Title("The definition namespace for the Database server used in a Nox solution.")]
        [Description("Specify properties pertinent to the solution Database server here. Examples include name, serverUri, Port and connection credentials")]
        [AdditionalProperties(false)]
        public DatabaseServer DatabaseServer { get; internal set; } = new();

        [Title("The definition namespace for the Cache server used in a Nox solution.")]
        [Description("Specify properties pertinent to the solution Cache server here. Examples include name, serverUri, Port and connection credentials")]
        [AdditionalProperties(false)]
        public CacheServer? CacheServer { get; internal set; }

        [Title("The definition namespace for the Search server used in a Nox solution.")]
        [Description("Specify properties pertinent to the solution Search server here. Examples include name, serverUri, Port and connection credentials")]
        [AdditionalProperties(false)]
        public SearchServer? SearchServer { get; internal set; }

        [Title("The definition namespace for the Event Source server used in a Nox solution.")]
        [Description("Specify properties pertinent to the solution Event Source server here. Examples include name, serverUri, Port and connection credentials")]
        [AdditionalProperties(false)]
        public EventSourceServer? EventSourceServer { get; internal set; }
    }
}
