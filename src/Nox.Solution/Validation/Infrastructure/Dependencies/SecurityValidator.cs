using System.Collections.Generic;
using FluentValidation;

namespace Nox
{
    internal class SecurityValidator: AbstractValidator<Security>
    {
        public SecurityValidator(IEnumerable<ServerBase>? servers)
        {
            RuleFor(p => p.Secrets!)
                .SetValidator(new SecretsValidator(servers));
        }
    }
}