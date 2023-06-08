using System.Collections.Generic;
using FluentValidation;

namespace Nox
{
    internal class ImServerValidator: AbstractValidator<ImServer>
    {
        public ImServerValidator(IEnumerable<ServerBase>? servers)
        {
            Include(new ServerBaseValidator("the infrastructure, dependencies, notifications, im server", servers));
            RuleFor(p => p.Provider)
                .NotEmpty()
                .WithMessage(p => string.Format(ValidationResources.ImServerProviderEmpty, p.Name, ImServerProviderHelpers.NameList()));
        }
    }
}