using System.Collections.Generic;
using FluentValidation;

namespace Nox.Solution.Validation;

public class ApiServerValidator: AbstractValidator<ApiServer>
{
    public ApiServerValidator(IEnumerable<ServerBase>? servers)
    {
        Include(new ServerBaseValidator("the infrastructure, endpoints, API server", servers));
        RuleFor(p => p.Provider)
            .NotEmpty()
            .WithMessage(p => string.Format(ValidationResources.ApiServerProviderEmpty, p.Name, ApiServerProviderHelpers.NameList()));
    }
}