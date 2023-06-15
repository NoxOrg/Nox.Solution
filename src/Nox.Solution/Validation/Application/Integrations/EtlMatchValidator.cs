using FluentValidation;

namespace Nox.Solution.Validation
{
    public class EtlMatchValidator: AbstractValidator<IntegrationMatch>
    {
        public EtlMatchValidator(string etlName)
        {
            RuleFor(p => p.Table)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.EtlMatchTableEmpty, etlName));
            
            RuleFor(p => p.LookupColumn)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.EtlMatchLookupColumnEmpty, etlName));
            
            RuleFor(p => p.ReturnColumn)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.EtlMatchReturnColumnEmpty, etlName));
        }
    }
}