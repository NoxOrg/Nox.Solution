using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Nox.Validation.Base;

namespace Nox.Validation.Domain
{
    public class EntityValidator: AbstractValidator<Entity>
    {
        private readonly IEnumerable<Entity>? _entities;

        public EntityValidator(IEnumerable<Entity>? entities)
        {
            if (entities == null) return;
            _entities = entities;
            
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage(t => string.Format(ValidationResources.EntityNameEmpty));
            
            RuleFor(e => e.ApplyDefaults())
                .NotEqual(false)
                .WithMessage(e => string.Format(ValidationResources.EntityDefaultsFalse, e.Name));
            
            RuleFor(e => e.Name).Must(MustHaveUniqueName)
                .WithMessage(e => string.Format(ValidationResources.EntityNameDuplicate, e.Name));

            RuleForEach(e => e.Relationships)
                .SetValidator(e => new EntityRelationshipValidator(e.Name, e.Relationships, _entities));

            RuleForEach(e => e.OwnedRelationships)
                .SetValidator(v => new EntityOwnedRelationshipValidator(v.Name, v.OwnedRelationships, _entities));

            RuleForEach(e => e.Queries)
                .SetValidator(e => new DomainQueryValidator(e.Queries, e.Name));

            RuleForEach(e => e.Commands)
                .SetValidator(v => new DomainCommandValidator(v.Commands, v.Name));

            RuleForEach(p => p.Keys)
                .SetValidator(v => new SimpleTypeValidator($"One of the keys for entity {v.Name}", "keys"));

            RuleForEach(p => p.Attributes)
                .SetValidator(v => new SimpleTypeValidator($"an Attribute of entity '{v.Name}'", "entity attributes"));

        }
        
        private bool MustHaveUniqueName(Entity toEvaluate, string name)
        {
            return _entities!.All(entity => entity.Equals(toEvaluate) || entity.Name != name);
        }
    }
}