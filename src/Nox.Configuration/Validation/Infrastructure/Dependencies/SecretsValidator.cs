using System.Collections.Generic;
using FluentValidation;
using Nox.Configuration.Validation.Base;

namespace Nox.Configuration.Validation
{
    public class SecretsValidator: AbstractValidator<Secrets>
    {
        public SecretsValidator(IEnumerable<ServerBase>? servers)
        {
            RuleFor(p => p.SecretsServer!)
                .SetValidator(v => new SecretsServerValidator(servers));

            RuleFor(p => p.ValidFor!)
                .Must(HaveValidTimespan)
                .WithMessage(string.Format(ValidationResources.SecretsValidForInvalidTimespan, "infrastructure, security, secrets"));

        }
        
        private bool HaveValidTimespan(SecretsValidFor toEvaluate)
        {
            if (toEvaluate.Days == null && toEvaluate.Hours == null && toEvaluate.Minutes == null && toEvaluate.Seconds == null) return false;
            if (toEvaluate.Days!.Value == 0 && toEvaluate.Days!.Value == 0 && toEvaluate.Minutes!.Value == 0 && toEvaluate.Seconds!.Value == 0) return false;
            return true;
        }
    }
}