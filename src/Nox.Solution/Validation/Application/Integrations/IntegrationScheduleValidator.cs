using FluentValidation;

namespace Nox.Solution.Validation
{
    public class IntegrationScheduleValidator: AbstractValidator<IntegrationSchedule>
    {
        public IntegrationScheduleValidator(string sourceName, string etlName)
        {
            RuleFor(p => p.Start)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.EtlScheduleStartEmpty, sourceName, etlName));
        }
    }
}