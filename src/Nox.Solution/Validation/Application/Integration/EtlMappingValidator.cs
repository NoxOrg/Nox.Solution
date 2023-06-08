using FluentValidation;

namespace Nox.Solution.Validation
{
    public class EtlMappingValidator: AbstractValidator<EtlMapping>
    {
        public EtlMappingValidator(string etlName)
        {
            RuleFor(p => p.SourceColumn)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.EtlMappingSourceColumnMissing, etlName));

            RuleFor(p => p.TargetAttribute)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.EtlMappingTargetAttributeMissing, etlName));
        }
    }
}