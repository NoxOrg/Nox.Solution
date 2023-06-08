using System.Collections.Generic;
using FluentValidation;
using Nox.Configuration.Validation.Base;

namespace Nox.Configuration.Validation
{
    public class SmsServerValidator: AbstractValidator<SmsServer>
    {
        public SmsServerValidator(IEnumerable<ServerBase>? servers)
        {
            Include(new ServerBaseValidator("the infrastructure, dependencies, notifications, sms server", servers));
            RuleFor(p => p.Provider)
                .NotEmpty()
                .WithMessage(p => string.Format(ValidationResources.SmsServerProviderEmpty, p.Name, SmsServerProviderHelpers.NameList()));
        }
    }
}