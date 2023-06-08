using System.Collections.Generic;
using FluentValidation;

namespace Nox
{
    internal class EmailServerValidator: AbstractValidator<EmailServer>
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