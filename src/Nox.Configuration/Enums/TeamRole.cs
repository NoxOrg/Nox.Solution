using System;
using System.Linq;

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
    
    public static class TeamRoleHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(TeamRole))
                .Cast<TeamRole>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}