using System.Collections.Generic;
using FluentValidation;
using Nox.Configuration.Validation.Base;

namespace Nox.Configuration.Validation
{
    public class MessagingValidator: AbstractValidator<Messaging>
    {
        public MessagingValidator(IEnumerable<ServerBase>? servers)
        {
            RuleFor(p => p.DomainEventServer!)
                .SetValidator(v => new ServerBaseValidator("the infrastructure, messaging, domain event server", servers));
            
            RuleFor(p => p.IntegrationEventServer!)
                .SetValidator(v => new ServerBaseValidator("the infrastructure, messaging, integration event server", servers));
        }
    }
}