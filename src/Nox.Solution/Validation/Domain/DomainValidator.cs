using FluentValidation;

namespace Nox.Validation.Domain
{
    public class DomainValidator: AbstractValidator<Nox.Domain>
    {
        public DomainValidator()
        {
            RuleFor(d => d.Entities)
                .NotEmpty()
                .WithMessage(t => string.Format(ValidationResources.DomainEntitiesEmpty));

            RuleForEach(d => d.Entities)
                .SetValidator(v => new EntityValidator(v.Entities));
        }
    }
}