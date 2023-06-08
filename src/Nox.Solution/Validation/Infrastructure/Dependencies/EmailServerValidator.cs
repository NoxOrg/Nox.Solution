using System.Collections.Generic;
using FluentValidation;
using Nox.Configuration.Validation.Base;

namespace Nox.Configuration.Validation
{
    public class EmailServerValidator: AbstractValidator<EmailServer>
    {
        public EmailServerValidator(IEnumerable<ServerBase>? servers)
        {
            Include(new ServerBaseValidator("the infrastructure, dependencies, notifications, email server", servers));
            RuleFor(p => p.Provider)
                .NotEmpty()
                .WithMessage(p => string.Format(ValidationResources.EmailServerProviderEmpty, p.Name, EmailServerProviderHelpers.NameList()));
        }
    }
}