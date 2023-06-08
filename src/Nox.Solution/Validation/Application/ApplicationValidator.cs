using System.Collections.Generic;
using FluentValidation;
using Nox.Validation.Application.DataTransferObjects;
using Nox.Validation.Application.Integration;

namespace Nox.Validation.Application
{
    public class ApplicationValidator: AbstractValidator<Nox.Application>
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