using System.Collections.Generic;
using FluentValidation;

namespace Nox.Configuration.Validation
{
    public class ApplicationValidator: AbstractValidator<Application>
    {
        public ApplicationValidator(IEnumerable<DataConnection>? dataConnections)
        {
            RuleForEach(p => p.DataTransferObjects)
                .SetValidator(v => new DataTransferObjectValidator(v.DataTransferObjects));

            RuleForEach(p => p.Integration)
                .SetValidator(v => new IntegrationValidator(v.Integration, dataConnections));
        }
    }
}