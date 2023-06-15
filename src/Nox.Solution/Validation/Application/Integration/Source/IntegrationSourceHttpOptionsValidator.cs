using FluentValidation;

namespace Nox.Solution.Validation;

public class IntegrationSourceHttpOptionsValidator: AbstractValidator<IntegrationSourceHttpOptions?>
{
    internal IntegrationSourceHttpOptionsValidator(string integrationName)
    {
        RuleFor(opt => opt!.Route)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceHttpOptionsRouteEmpty, integrationName));

        RuleFor(opt => opt!.Format)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceHttpOptionsFormatEmpty, integrationName));
        
        RuleFor(opt => opt!.Verb)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceHttpOptionsVerbEmpty, integrationName));


    }
}