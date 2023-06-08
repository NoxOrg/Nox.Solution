using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox.Validation.Base
{
    public class ServerBaseValidator: AbstractValidator<ServerBase>
    {
        private readonly IEnumerable<ServerBase>? _servers;

        public ServerBaseValidator(string description, IEnumerable<ServerBase>? servers)
        {
            _servers = servers;
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.ServerNameEmpty, description));

            RuleFor(p => p.Name!)
                .Must(HaveUniqueName)
                .WithMessage(m => string.Format(ValidationResources.ServerNameDuplicate, m.Name, description));
        }
        
        private bool HaveUniqueName(ServerBase toEvaluate, string name)
        {
            return _servers!.All(svr => svr.Equals(toEvaluate) || svr.Name != name);
        }
    }
}