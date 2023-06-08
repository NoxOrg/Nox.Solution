using Json.Schema.Generation;
using System.Collections.Generic;
using Humanizer;

namespace Nox.Solution
{

    [Title("Defines an entity or aggregate root")]
    [Description("The declaration of an entity, it's attributes, commands and queries. See https://noxorg.dev for more.")]
    [AdditionalProperties(false)]
    public class Entity : DefinitionBase
    {

        [Required]
        [Title("The name of the entity. Contains no spaces.")]
        [Description("The name of the abstract or real-world entity. It should be a commonly used singular noun and be unique within a solution.")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; internal set; } = string.Empty;

        [Title("A phrase describing the entity.")]
        [Description("A description of the entity and what it represents in the real world.")]
        public string? Description { get; internal set; }

        [Title("The pluraly name of the entity. Contains no spaces")]
        [Description("The name for a set, group or collection of the entity. NOX will guess the plural if it is not supplied.")]
        [Pattern(@"^[^\s]*$")]
        public string PluralName { get; internal set; } = string.Empty;

        public EntityUserInterface? UserInterface { get; internal set; }
      
        [Title("Specifies information on storing and retrieving entities")]
        [Description("Provides hints to the database engine and API as to how this entity should be managed in the persistence store.")]
        [AdditionalProperties(false)]
        public EntityPersistence? Persistence { get; internal set; }

        [Title("Defines relationships to other entities.")]
        [Description("Defines one way relationships to other entities. Remember to define the reverse relationship on the target entities.")]
        [AdditionalProperties(false)]
        public List<EntityRelationship>? Relationships { get; internal set; }

        [Title("Defines owned relationships to another entity.")]
        [Description("Defines relationship to owned entities. This entity will be treated as an aggregate root.")]
        [AdditionalProperties(false)]
        public List<EntityOwnedRelationship>? OwnedRelationships { get; internal set; }

        [Title("Defines queries for the domain.")]
        [Description("Defines queries for the domain that operates on this entity. Queries should have no side effects and not mutate the domain state.")]
        [AdditionalProperties(false)]
        public List<DomainQuery>? Queries { get; internal set; }

        [Title("Defines commands for the domain.")]
        [Description("Defines commands for the domain that operates on this entity. Commands may have side effects and mutate the domain state.")]
        [AdditionalProperties(false)]
        public List<DomainCommand>? Commands { get; internal set; }

        [AdditionalProperties(false)]
        public List<NoxSimpleTypeDefinition>? Keys { get; internal set; }
        
        [AdditionalProperties(false)]
        public List<NoxSimpleTypeDefinition>? Attributes { get; internal set; }

        internal bool ApplyDefaults()
        {
            if (string.IsNullOrWhiteSpace(PluralName)) PluralName = Name.Pluralize();
            return true;
        }
    }
}