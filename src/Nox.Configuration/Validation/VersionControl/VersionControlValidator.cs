using FluentValidation;

namespace Nox.Configuration.Validation
{
    public class VersionControlValidator: AbstractValidator<VersionControl>
    {
        public VersionControlValidator()
        {
            RuleFor(vc => vc.Provider)
                .NotEmpty()
                .WithMessage(vc => string.Format(ValidationResources.VersionControlProviderEmpty, vc.Ref));

            RuleFor(vc => vc.Host)
                .NotEmpty()
                .WithMessage(vc => string.Format(ValidationResources.VersionControlHostEmpty, vc.Ref));

            RuleFor(vc => vc.Folders!)
                .SetValidator(vc => new VersionControlFoldersValidator());
        }
    }
}