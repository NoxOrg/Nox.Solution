using FluentValidation;

namespace Nox
{
    internal class SolutionValidator: AbstractValidator<Solution>
    {
        public SolutionValidator()
        {
            RuleFor(solution => solution.Name)
                .NotEmpty()
                .WithMessage(solution => string.Format(ValidationResources.SolutionNameEmpty));
            
            RuleForEach(sln => sln.Environments)
                .SetValidator(sln => new EnvironmentValidator(sln.Environments));

            RuleFor(sln => sln.VersionControl!)
                .SetValidator(new VersionControlValidator());

            RuleForEach(sln => sln.Team)
                .SetValidator(sln => new TeamValidator(sln.Team));

            RuleFor(sln => sln.Domain!)
                .SetValidator(new DomainValidator());

            RuleFor(sln => sln.Application!)
                .SetValidator(sln => new ApplicationValidator(sln.Infrastructure?.Dependencies?.DataConnections));

            RuleFor(sln => sln.Infrastructure!)
                .SetValidator(new InfrastructureValidator());
        }
    }
}