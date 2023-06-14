using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation
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

            RuleFor(p => p.TargetType)
                .NotEmpty()
                .WithMessage(p => string.Format(ValidationResources.EtlTargetTypeEmpty, p.Name, etlName, EtlTargetType.Entity.ToNameList()));
            
            RuleFor(p => p.DataConnection)
                .Must(HaveValidDataConnection)
                .WithMessage(m => string.Format(ValidationResources.EtlTargetDataConnectionMissing, m.Name, etlName, m.DataConnection));
        }
        
        private bool HaveValidDataConnection(string? dataConnectionName)
        {
            if (!string.IsNullOrWhiteSpace(dataConnectionName))
            {
                return _dataConnections!.Any(dc => dc.Name == dataConnectionName);    
            }

            return true;
        }
    }
}