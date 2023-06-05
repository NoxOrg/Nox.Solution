using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox.Configuration.Validation
{
    public class EntityValidator: AbstractValidator<Entity>
    {
        private readonly IEnumerable<Entity> _entities;

        public EntityValidator(IEnumerable<Entity> entities)
        {
            _entities = entities;
            
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage(t => string.Format(ValidationResources.EntityNameEmpty, t.Ref));
            
            RuleFor(e => e.Name).Must(MustHaveUniqueName)
                .WithMessage(env => string.Format(ValidationResources.EntityNameDuplicate, env.Name, env.Ref));
        }
        
        private bool MustHaveUniqueName(Entity toEvaluate, string name)
        {
            return _entities.All(entity => entity.Equals(toEvaluate) || entity.Name != name);
        }
    }
}