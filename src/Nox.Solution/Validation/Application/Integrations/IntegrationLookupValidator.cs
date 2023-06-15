using FluentValidation;

namespace Nox.Solution.Validation
{
    public class IntegrationLookupValidator: AbstractValidator<IntegrationLookup>
    {
        public IntegrationLookupValidator(string etlName)
        {
            RuleFor(p => p.SourceColumn)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.EtlLookupSourceColumnEmpty, etlName));

            RuleFor(p => p.Match)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.EtlLookupMatchEmpty, etlName));

            RuleFor(p => p.Match!)
                .SetValidator(new IntegrationMatchValidator(etlName));
            
            RuleFor(p => p.TargetAttribute)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.EtlLookupTargetAttributeEmpty, etlName));
        }
    }
}