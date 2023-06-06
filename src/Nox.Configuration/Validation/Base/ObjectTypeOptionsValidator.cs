using FluentValidation;

namespace Nox.Configuration.Validation.Base
{
    public class ObjectTypeOptionsValidator: AbstractValidator<ObjectTypeOptions>
    {
        public ObjectTypeOptionsValidator(string description)
        {
            RuleFor(p => p.Attributes)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.ObjectTypeOptionsAttributesEmpty, description));
        }
    }
}