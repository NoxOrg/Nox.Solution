using FluentValidation;

namespace Nox.Configuration.Validation
{
    public class EntityPersistenceValidator: AbstractValidator<EntityPersistence>
    {
        public EntityPersistenceValidator(string entityName)
        {
            RuleFor(ep => ep.ApplyDefaults(entityName))
                .NotEqual(false)
                .WithMessage(e => string.Format(ValidationResources.EntityPersistenceDefaultsFalse, entityName));

            RuleFor(ep => ep.TableName)
                .NotEmpty()
                .WithMessage(ep => string.Format(ValidationResources.EntityPersistenceTableNameEmpty, entityName));
        }
    }
}