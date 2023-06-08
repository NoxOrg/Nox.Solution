using System.Collections.Generic;
using FluentValidation;

namespace Nox
{
    internal class DataConnectionValidator: AbstractValidator<DataConnection>
    {
        public DataConnectionValidator(IEnumerable<ServerBase>? servers)
        {
            Include(new ServerBaseValidator("an infrastructure, dependencies, data connection", servers));
            RuleFor(p => p.Provider)
                .NotEmpty()
                .WithMessage(p => string.Format(ValidationResources.DataConnectionProviderEmpty, p.Name, DataConnectionProviderHelpers.NameList()));
        }
    }
}