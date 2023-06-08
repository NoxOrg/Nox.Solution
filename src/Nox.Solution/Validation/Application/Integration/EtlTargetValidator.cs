using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox.Validation.Application.Integration
{
    public class EtlTargetValidator: AbstractValidator<EtlTarget>
    {
        private readonly IEnumerable<DataConnection>? _dataConnections;

        public EtlTargetValidator(string etlName, IEnumerable<DataConnection>? dataConnections)
        {
            _dataConnections = dataConnections;
            
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.EtlTargetNameEmpty, etlName));

            RuleFor(p => p.DataConnection)
                .NotEmpty()
                .WithMessage(p => string.Format(ValidationResources.EtlTargetDataConnectionEmpty, p.Name, etlName));
            
            RuleFor(p => p.DataConnection!)
                .Must(HaveValidDataConnection)
                .WithMessage(m => string.Format(ValidationResources.EtlTargetDataConnectionMissing, m.Name, etlName, m.DataConnection));
        }
        
        private bool HaveValidDataConnection(string dataConnectionName)
        {
            return _dataConnections!.Any(dc => dc.Name == dataConnectionName);
        }
    }
}