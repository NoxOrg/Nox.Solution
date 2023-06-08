using FluentValidation;

namespace Nox.Validation.Application.Integration
{
    public class EtlScheduleValidator: AbstractValidator<EtlSchedule>
    {
        public EtlScheduleValidator(string sourceName, string etlName)
        {
            RuleFor(p => p.Start)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.EtlScheduleStartEmpty, sourceName, etlName));
        }
    }
}