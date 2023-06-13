using System.Collections.Generic;
using FluentValidation;

namespace Nox.Solution.Validation
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