using FluentValidation;

namespace Nox.Configuration.Validation
{
    public class TeamValidator: AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(t => t.UserName)
                .NotEmpty()
                .WithMessage(t => string.Format(ValidationResources.TeamUserNameEmpty, t.Ref));

            RuleFor(t => t.Roles)
                .NotEmpty()
                .WithMessage(t => string.Format(ValidationResources.TeamRolesEmpty, t.Ref));
        }
    }
}