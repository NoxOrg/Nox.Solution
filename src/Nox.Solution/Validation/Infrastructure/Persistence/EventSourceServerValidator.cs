using System.Collections.Generic;
using FluentValidation;

namespace Nox.Solution.Validation;

public class EventSourceServerValidator: AbstractValidator<EventSourceServer>
{
    public EventSourceServerValidator(IEnumerable<ServerBase>? servers)
    {
        Include(new ServerBaseValidator("the infrastructure, persistence, event source server", servers));
        RuleFor(p => p.Provider)
            .NotEmpty()
            .WithMessage(p => string.Format(ValidationResources.EventSourceServerProviderEmpty, p.Name, EventSourceServerProviderHelpers.NameList()));
    }
}