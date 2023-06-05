using FluentValidation;

namespace Nox.Configuration.Validation
{
    public class SolutionValidator: AbstractValidator<Solution>
    {
        public SolutionValidator()
        {
            RuleFor(solution => solution.Name)
                .NotEmpty()
                .WithMessage(solution => string.Format(ValidationResources.SolutionNameEmpty, solution.Ref));
            
            RuleForEach(sln => sln.Environments)
                .SetValidator(sln => new EnvironmentValidator(sln.Environments));

            RuleFor(sln => sln.VersionControl!)
                .SetValidator(new VersionControlValidator());

            RuleForEach(sln => sln.Team)
                .SetValidator(new TeamValidator());
        }
    }
}