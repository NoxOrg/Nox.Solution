using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox.Configuration.Validation
{
    public class TeamValidator: AbstractValidator<Team>
    {
        private readonly IEnumerable<Team>? _members;
        
        public TeamValidator(IEnumerable<Team>? members)
        {
            if (members == null) return;
            _members = members;
            
            RuleFor(t => t.UserName)
                .NotEmpty()
                .WithMessage(t => string.Format(ValidationResources.TeamUserNameEmpty, t.Ref));

            RuleFor(t => t.Roles)
                .NotEmpty()
                .WithMessage(t => string.Format(ValidationResources.TeamRolesEmpty, t.Ref));
            
            RuleFor(t => t.UserName).Must(MustHaveUniqueUserName)
                .WithMessage(env => string.Format(ValidationResources.EnvironmentNameDuplicate, env.Name, env.Ref));
        }
        
        private bool MustHaveUniqueUserName(Team toEvaluate, string userName)
        {
            return _members!.All(member => member.Equals(toEvaluate) || member.UserName != userName);
        }
    }
}