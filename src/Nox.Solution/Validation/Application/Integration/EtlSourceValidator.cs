using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox
{
    internal class EtlSourceValidator: AbstractValidator<EtlSource>
    {
        private readonly IEnumerable<DataConnection>? _dataConnections;
        
        public EtlSourceValidator(string etlName, IEnumerable<DataConnection>? dataConnections)
        {
            _dataConnections = dataConnections;
            
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.EtlSourceNameEmpty, etlName));

            RuleFor(p => p.DataConnection)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.EtlSourceDataConnectionEmpty, m.Name, etlName));

            RuleFor(p => p.DataConnection!)
                .Must(HaveValidDataConnection)
                .WithMessage(m => string.Format(ValidationResources.EtlSourceDataConnectionMissing, m.Name, etlName, m.DataConnection));
                

            RuleFor(p => p.Schedule!)
                .SetValidator(v => new EtlScheduleValidator(v.Name, etlName));
        }
        
        private bool HaveValidDataConnection(string dataConnectionName)
        {
            return _dataConnections!.Any(dc => dc.Name == dataConnectionName);
        }
    }
}