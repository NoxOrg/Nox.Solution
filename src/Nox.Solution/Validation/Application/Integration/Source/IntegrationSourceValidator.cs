using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox.Solution.Validation
{
    public class IntegrationSourceValidator: AbstractValidator<IntegrationSource?>
    {
        private readonly IEnumerable<DataConnection>? _dataConnections;
        
        public IntegrationSourceValidator(string integrationName, IEnumerable<DataConnection>? dataConnections, string dataConnectionName)
        {
            _dataConnections = dataConnections;
            
            RuleFor(source => source!.Name)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.IntegrationSourceNameEmpty, integrationName))
                .Must(HaveValidDataConnection)
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceDataConnectionMissing, source!.Name, integrationName));

            RuleFor(source => source!.Schedule!)
                .SetValidator(source => new IntegrationScheduleValidator(source!.Name, integrationName));
            
            var dataConnection = _dataConnections!.First(dc => dc.Name.Equals(dataConnectionName));

            RuleFor(source => source!.DatabaseOptions)
                .NotNull()
                .WithMessage(source => string.Format(ValidationResources.IntegrationSourceDatabaseOptionsEmpty, source!.Name, integrationName))
                .SetValidator(source => new IntegrationSourceDatabaseOptionsValidator(integrationName))
                .When(_ => dataConnection.Provider is DataConnectionProvider.Postgres or DataConnectionProvider.MySql or DataConnectionProvider.SqLite or DataConnectionProvider.SqlServer);

        }
        
        private bool HaveValidDataConnection(string dataConnectionName)
        {
            return _dataConnections!.Any(dc => dc.Name == dataConnectionName);
        }
    }
}