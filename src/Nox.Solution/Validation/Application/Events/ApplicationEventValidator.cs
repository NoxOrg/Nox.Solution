using FluentValidation;

namespace Nox.Solution.Validation.Application.Events;

public class ApplicationEventValidator: AbstractValidator<ApplicationEvent>
{
    public ApplicationEventValidator()
    {
        RuleFor(ae => ae.Name)
            .NotEmpty()
            .WithMessage(de => string.Format(ValidationResources.ApplicationEventNameEmpty));
        
        RuleForEach(ae => ae.Attributes)
            .SetValidator(ae => new SimpleTypeValidator($"An Attribute of application event '{ae.Name}'", "application event attributes"));
    }
}