using System.Collections.Generic;
using FluentValidation;

namespace Nox.Solution.Validation
{
    public class EndpointsValidator: AbstractValidator<Endpoints>
    {
        public EndpointsValidator(IEnumerable<ServerBase>? servers)
        {
            RuleFor(p => p.ApiServer!)
                .SetValidator(v => new ServerBaseValidator("the infrastructure, endpoints, api server", servers));
            
            RuleFor(p => p.BffServer!)
                .SetValidator(v => new ServerBaseValidator("the infrastructure, endpoints, bff server", servers));
        }
    }
}