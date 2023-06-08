using System.Collections.Generic;
using FluentValidation;
using Nox.Validation.Base;

namespace Nox.Validation.Infrastructure.Endpoints
{
    public class EndpointsValidator: AbstractValidator<Nox.Endpoints>
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