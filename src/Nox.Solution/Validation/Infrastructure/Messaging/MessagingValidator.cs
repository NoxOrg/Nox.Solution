using System.Collections.Generic;
using FluentValidation;
using Nox.Validation.Base;

namespace Nox.Validation.Infrastructure.Messaging
{
    public class MessagingValidator: AbstractValidator<Nox.Messaging>
    {
        public MessagingValidator(IEnumerable<ServerBase>? servers)
        {
            RuleFor(p => p.IntegrationEventServer!)
                .SetValidator(v => new ServerBaseValidator("the infrastructure, messaging, integration event server", servers));
            
            RuleFor(p => p.IntegrationEventServer!.ApplyDefaults())
                .NotEqual(false)
                .WithMessage(e => string.Format(ValidationResources.IntegrationEventsServerDefaultsFalse));
        }
    }
}