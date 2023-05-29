using Json.Schema.Generation;
using System.Collections.Generic;

namespace Nox
{

    public enum TeamRole
    {
        Administrator,
        Owner,
        Manager,
        Developer,
        QualityAssurer,
        Architect,
        Tester,
        RequirementAnalyst,
        EndUser,
        UserExperienceDesigner,
        DevOpsEngineer,
        SupportEngineer,
        TechnicalWriter,
        DatabaseAdministrator,
        ReleaseEngineer,
        ProjectManager
    }

    [Title("Information about the team working on this solution.")]
    [Description("Specify the members of the team working on the solution including their respective roles.")]
    [AdditionalProperties(false)]
    public class Team : DefinitionBase
    {

        [Title("The name and surname of the team member.")]
        [Description("The name and surname of the member in the team.")]
        public string? Name { get; set; }

        [Required]
        [Title("The version control and organizational user name for the user.")]
        [Description("The user name/email for the user on Github, Azure Devops or another source versioning platform")]
        [Pattern(@"^[^\s]*$")]
        public string? UserName { get; set; }

        [AdditionalProperties(false)]
        public List<TeamRole>? Roles { get; set; }
    }
}