using System.Collections.Generic;
using FluentValidation;

namespace Nox.Validation.Infrastructure.Dependencies
{
    public class SecurityValidator: AbstractValidator<Security>
    {
        public SecurityValidator(IEnumerable<ServerBase>? servers)
        {
            RuleFor(p => p.Secrets!)
                .SetValidator(new SecretsValidator(servers));
        }
    }
}