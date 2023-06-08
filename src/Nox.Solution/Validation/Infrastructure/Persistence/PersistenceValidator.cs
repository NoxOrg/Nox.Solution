using System.Collections.Generic;
using FluentValidation;

namespace Nox.Solution.Validation
{
    public class PersistenceValidator: AbstractValidator<Persistence>
    {
        public PersistenceValidator(IEnumerable<ServerBase>? servers)
        {
            RuleFor(p => p.DatabaseServer)
                .NotEmpty()
                .WithMessage(ValidationResources.PersistenceDatabaseServerEmpty);

            RuleFor(p => p.DatabaseServer!)
                .SetValidator(v => new ServerBaseValidator("the infrastructure, persistence, database server", servers));

            RuleFor(p => p.CacheServer!)
                .SetValidator(v => new ServerBaseValidator("the infrastructure, cache server", servers));
            
            RuleFor(p => p.SearchServer!)
                .SetValidator(v => new ServerBaseValidator("the infrastructure, search server", servers));
            
            RuleFor(p => p.EventSourceServer!)
                .SetValidator(v => new ServerBaseValidator("the infrastructure, event source server", servers));
        }
    }
}