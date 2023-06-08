using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox.Validation.Team
{
    public class TeamValidator: AbstractValidator<Nox.Team>
    {
        private readonly IEnumerable<Nox.Team>? _members;
        
        public TeamValidator(IEnumerable<Nox.Team>? members)
        {
            if (members == null) return;
            _members = members;
            
            RuleFor(t => t.UserName)
                .NotEmpty()
                .WithMessage(t => string.Format(ValidationResources.TeamUserNameEmpty));

            RuleFor(t => t.Roles)
                .NotEmpty()
                .WithMessage(t => string.Format(ValidationResources.TeamRolesEmpty, t.UserName));
            
            RuleFor(t => t.UserName).Must(HaveUniqueUserName)
                .WithMessage(t => string.Format(ValidationResources.TeamUserNameDuplicate, t.UserName));
        }
        
        private bool HaveUniqueUserName(Nox.Team toEvaluate, string userName)
        {
            return _members!.All(member => member.Equals(toEvaluate) || member.UserName != userName);
        }
    }
}