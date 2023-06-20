using FluentValidation;

namespace Nox.Solution.Validation;

public class DomainEventValidator: AbstractValidator<DomainEvent>
{
    public DomainEventValidator()
    {
        RuleFor(de => de.Name)
            .NotEmpty()
            .WithMessage(de => string.Format(ValidationResources.DomainEventNameEmpty));
        
        RuleForEach(de => de.Attributes)
            .SetValidator(de => new SimpleTypeValidator($"An Attribute of domain event '{de.Name}'", "domain event attributes"));
    }
}