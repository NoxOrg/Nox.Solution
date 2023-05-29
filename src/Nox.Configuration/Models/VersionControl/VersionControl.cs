using Json.Schema.Generation;
using System;

namespace Nox
{

    public enum VersionControlProvider
    {
        AzureDevops
    }

    [Title("Source code repository and related info for the solution.")]
    [Description("Contains information about where source code is kept and the folders of the main components thereof.")]
    [AdditionalProperties(false)]
    public class VersionControl : DefinitionBase
    {

        [Required]
        [Title("The source code and repository provider or service.")]
        [Description("The name of of the provider or service for source code and version control.")]
        [Pattern(@"^[^\s]*$")]
        public VersionControlProvider Provider { get; set; } = VersionControlProvider.AzureDevops;

        [Required]
        [Title("The URI for the host of the version control service.")]
        [Description("The URI for the person or organization's projects and reporitories. Usually https://dev.azure.com/<organization>")]
        [Pattern(@"^[^\s]*$")]
        public Uri? Host { get; set; }

        [AdditionalProperties(false)]
        public VersionControlFolders? Folders { get; set; }
    }
}