using System.Collections.Generic;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation;

public class CacheServerValidator: AbstractValidator<CacheServer>
{
    public CacheServerValidator(IEnumerable<ServerBase>? servers)
    {
        Include(new ServerBaseValidator("the infrastructure, persistence, cache server", servers));
        RuleFor(p => p.Provider)
            .NotEmpty()
            .WithMessage(p => string.Format(ValidationResources.CacheServerProviderEmpty, p.Name, CacheServerProvider.Memcached.ToNameList()));
    }
}