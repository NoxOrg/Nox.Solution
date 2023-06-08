using System.Collections.Generic;
using FluentValidation;
using Nox.Configuration.Validation.Base;

namespace Nox.Configuration.Validation
{
    public class SecretsServerValidator: AbstractValidator<SecretsServer>
    {
        public SecretsServerValidator(IEnumerable<ServerBase>? servers)
        {
            Include(new ServerBaseValidator("the infrastructure, dependencies, security, secrets, secrets server", servers));
            RuleFor(p => p.Provider)
                .NotEmpty()
                .WithMessage(p => string.Format(ValidationResources.SecretsServerProviderEmpty, p.Name, SecretsServerProviderHelpers.NameList()));
        }
    }
}