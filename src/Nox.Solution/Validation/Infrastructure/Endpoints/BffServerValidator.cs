using System.Collections.Generic;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation;

public class BffServerValidator: AbstractValidator<BffServer>
{
    public BffServerValidator(IEnumerable<ServerBase>? servers)
    {
        Include(new ServerBaseValidator("the infrastructure, endpoints, bff server", servers));
        RuleFor(p => p.Provider)
            .NotEmpty()
            .WithMessage(p => string.Format(ValidationResources.BffServerProviderEmpty, p.Name, BffServerProvider.Blazor.ToNameList()));
    }
}