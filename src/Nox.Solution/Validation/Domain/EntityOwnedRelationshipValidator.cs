using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation
{
    public class EntityOwnedRelationshipValidator: AbstractValidator<EntityOwnedRelationship>
    {

        private readonly IEnumerable<EntityOwnedRelationship>? _relationships;
        private readonly IEnumerable<Entity>? _entities;
        
        public EntityOwnedRelationshipValidator(string entityName, IEnumerable<EntityOwnedRelationship>? relationships, IEnumerable<Entity>? entities)
        {
            if (relationships == null) return;
            if (entities == null) return;
            _entities = entities;
            _relationships = relationships;
            
            RuleFor(er => er.Name)
                .NotEmpty()
                .WithMessage(er => string.Format(ValidationResources.EntityOwnedRelationshipNameEmpty, entityName));
            
            RuleFor(er => er.Name).Must(HaveUniqueName)
                .WithMessage(er => string.Format(ValidationResources.EntityOwnedRelationshipNameDuplicate, er.Name));
            
            RuleFor(er => er.Description)
                .NotEmpty()
                .WithMessage(er => string.Format(ValidationResources.EntityOwnedRelationshipDescriptionEmpty, er.Name, entityName));
            
            RuleFor(er => er.Relationship)
                .NotEmpty()
                .WithMessage(er => string.Format(ValidationResources.EntityOwnedRelationshipRelationshipEmpty, er.Name, entityName, EntityRelationshipType.ExactlyOne.ToNameList()));
            
            RuleFor(er => er.Entity)
                .NotEmpty()
                .WithMessage(er => string.Format(ValidationResources.EntityOwnedRelationshipEntityEmpty, er.Name, entityName));
            
            RuleFor(er => er.Entity!).Must(ReferenceExistingEntity)
                .WithMessage(er => string.Format(ValidationResources.EntityOwnedRelationshipEntityMissing, er.Name, entityName, er.Entity));
            
        }
        
        private bool HaveUniqueName(EntityOwnedRelationship toEvaluate, string name)
        {
            //Check names in this entity relationships
            return _relationships!.All(rel => rel.Equals(toEvaluate) || rel.Name != name);
        }

        private bool ReferenceExistingEntity(EntityOwnedRelationship toEvaluate, string entityName)
        {
            return _entities!.Any(e => e.Name == entityName);
        }
    }
}