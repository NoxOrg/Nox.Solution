using System.Collections.Generic;
using FluentValidation;
using Nox.Validation.Base;

namespace Nox.Validation.Infrastructure.Dependencies
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