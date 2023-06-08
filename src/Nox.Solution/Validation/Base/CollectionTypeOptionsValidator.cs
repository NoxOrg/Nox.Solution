using FluentValidation;

namespace Nox.Validation.Base
{
    public class CollectionTypeOptionsValidator: AbstractValidator<ArrayTypeOptions>
    {
        public CollectionTypeOptionsValidator(string description)
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.CollectionTypeOptionsNameEmpty, description));
            
            RuleFor(p => p.Type)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.CollectionTypeOptionsTypeEmpty, description));

            RuleFor(p => p.ObjectTypeOptions!)
                .SetValidator(v => new ObjectTypeOptionsValidator(description));
        }
    }
}