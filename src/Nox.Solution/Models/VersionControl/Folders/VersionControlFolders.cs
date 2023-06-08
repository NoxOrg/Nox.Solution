using Json.Schema.Generation;

namespace Nox.Solution
{


    [Title("A list of well-known folders for the solution.")]
    [Description("The relative path to source code, tests, containers and other well known code assets.")]
    [AdditionalProperties(false)]
    public class VersionControlFolders : DefinitionBase
    {

        [Required]
        [Title("The path or relative path to the source code root.")]
        [Description("The path or relative path that contains your source code. Allows auto-configuration of build pipelines.")]
        public string? SourceCode { get; internal set; } = "/src";

        [Title("The path or relative path to the solution tests.")]
        [Description("The path or relative path that contains your solution tests. Allows auto-configuration of build pipelines.")]
        public string? Tests { get; internal set; } = "/tests";

        [Required]
        [Title("The path or relative path to the docker containers.")]
        [Description("The path or relative path that contains your solution docker containers.")]
        public string? Containers { get; internal set; } = "/Dockerfile";

        [Title("The path or relative path to the samples folder.")]
        [Description("The path or relative path that contains your solution samples.")]
        public string? Samples { get; internal set; }

        [Title("The path or relative path to the solution documentation.")]
        [Description("The path or relative path that contains your solution documentation.")]
        public string? Docs { get; internal set; }
    }
}