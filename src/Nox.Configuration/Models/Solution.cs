using Json.Schema.Generation;
using System;
using System.Collections.Generic;

namespace Nox
{

    [Title("Fully describes a NOX solution")]
    [Description("Contains all configuration, domain objects and infrastructure declarations that defines a NOX solution. See https://noxorg.dev for more.")]
    [AdditionalProperties(false)]
    public class Solution : DefinitionBase
    {

        [Required]
        [Title("The short name for the solution. Contains no spaces.")]
        [Description("The name of the NOX solution, application or service. This value is used extensively by the NOX tooling and libraries and should ideally be unique within an organisation.")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; set; } = string.Empty;

        [Title("A short description of the NOX solution.")]
        [Description("A brief description of the solution with what it's purpose or goals are.")]
        public string? Description { get; set; }

        [Title("URL to the documentation or specification of the solution.")]
        [Description("A URL which contains the requirements, documentation or specification for this solution.")]
        [Pattern(@"^[^\s]*$")]
        public Uri? Overview { get; set; }

        [Title("The environment variables used in your solution and default values.")]
        [Description("A key/value pair of environment variables used in your solution and their defaults.")]
        public Dictionary<string, string>? Variables { get; set; }

        [Title("Definitions for run-time environments.")]
        [Description("Definitions for the name, variables and other pertinent information pertaining to run-time environments.")]
        [AdditionalProperties(false)]
        public List<Environment>? Environments { get; set; }

        [AdditionalProperties(false)]
        public VersionControl? VersionControl { get; set; }

        [AdditionalProperties(false)]
        public List<Team>? Team { get; set; }

        [AdditionalProperties(false)]
        public Domain? Domain { get; set; }

        public Infrastructure? Infrastructure { get; set; }

    }
}