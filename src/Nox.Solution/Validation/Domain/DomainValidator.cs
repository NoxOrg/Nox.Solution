using FluentValidation;

namespace Nox.Configuration.Validation
{
    public class DomainValidator: AbstractValidator<Domain>
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