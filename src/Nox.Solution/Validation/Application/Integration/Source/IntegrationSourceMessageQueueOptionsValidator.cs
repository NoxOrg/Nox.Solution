using FluentValidation;

namespace Nox.Solution.Validation;

public class IntegrationSourceMessageQueueOptionsValidator: AbstractValidator<IntegrationSourceMessageQueueOptions>
{
    public IntegrationSourceMessageQueueOptionsValidator(string integrationName)
    {
        RuleFor(opt => opt!.Source)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceMsgQueueOptionsSourceEmpty, integrationName));
    }
}